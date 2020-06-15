using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        if(string.IsNullOrEmpty(s)){
            return new List<int>();
        }
        
        if(words.Length == 0){
            return new List<int>();
        }
        
        var result = new List<int>();
        var taken = new HashSet<int>();
        var wordFrequencies = GetWordFrequencies(words);
        var allWordsLength = AllWordsLength(words);
        for(int i = 0; i < s.Length - allWordsLength+1; i++){
            if(IsAllSubstrings(s, i, wordFrequencies)){
                result.Add(i);
            }
        }
        
        return result;
    }

    
    private bool IsAllSubstrings(string s, int startIndex, Dictionary<string, int> wordFrequencies) {
        
        int nonSkipped = 0;
        foreach(var key in wordFrequencies.Keys.ToList()){
            var value = wordFrequencies[key];
            if(value == 0) {
                continue;
            }
            
            nonSkipped++;
            
            if(IsSubstring(s, startIndex, key)){
                wordFrequencies[key]--;
                var result = IsAllSubstrings(s, startIndex+key.Length, wordFrequencies);
                wordFrequencies[key]++;
                if(result){
                    return true;
                }
            }
        }
        
        
        
        if(nonSkipped == 0)
            return true;
            
        
        return false;
    }
    
    private bool IsSubstring(string s, int startIndex, string word){
        for(int pos = 0; pos < word.Length; pos++){
            if(s[pos + startIndex] != word[pos]){
               return false; 
            }
        }
        
        return true;
    }
    
    private int AllWordsLength(string[] words){
        return words.Sum(w => w.Length);
    }
    
    Dictionary<string, int> GetWordFrequencies(string[] words){
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach(var word in words) {
            if(!result.ContainsKey(word)){
                result[word] = 1;
            } else {
                result[word]++;
            }
        }
        
        return result;
    }
}