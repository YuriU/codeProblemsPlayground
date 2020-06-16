using System.Collections.Generic;
using System.Linq;
public class SolutionWithSringIds {
    public IList<int> FindSubstring(string s, string[] words) {
        if(string.IsNullOrEmpty(s)){
            return new List<int>();
        }
        
        if(words.Length == 0){
            return new List<int>();
        }
        
        
        var wordLength = words[0].Length;
        var wordToId = MapStringsToIds(words);
        var wordIdFromPos = new int[s.Length];
        for(int i = 0; i < s.Length-wordLength+1;i++){
            var substr = s.Substring(i, wordLength);
            if(wordToId.ContainsKey(substr)){
                wordIdFromPos[i] = wordToId[substr];
            }
            else{
                wordIdFromPos[i] = -1;
            }
        }
        

        var result = new List<int>();
        var taken = new HashSet<int>();
        var wordFrequencies = GetWordIdsFrequencies(words, wordToId);
        var allWordsLength = AllWordsLength(words);
        for(int i = 0; i < s.Length - allWordsLength+1; i++) {
            if(IsAllSubstrings(wordIdFromPos, i, wordFrequencies, wordFrequencies.Keys.ToList(), wordLength)){
                result.Add(i);
            }
        }
        
        return result;
    }
    
    
    
    private bool IsAllSubstrings(int[] sIds, int startIndex, Dictionary<int, int> wordIdFrequencies, List<int> keys, int wordLength) {
        
        int nonSkipped = 0;
        foreach(var key in keys){
            var value = wordIdFrequencies[key];
            if(value == 0) {
                continue;
            }
            
            nonSkipped++;
            
            if(sIds[startIndex] == key){
                wordIdFrequencies[key]--;
                var result = IsAllSubstrings(sIds, startIndex+wordLength, wordIdFrequencies, keys, wordLength);
                wordIdFrequencies[key]++;
                if(result){
                    return true;
                }
            }
        }
        
                
        if(nonSkipped == 0)
            return true;
            
        
        return false;
    }
    
    
    private int AllWordsLength(string[] words){
        return words.Sum(w => w.Length);
    }
    
    private Dictionary<string, int> MapStringsToIds(string[] words) {
        Dictionary<string, int> stringToId = new Dictionary<string, int>();
        int id = 1;
        foreach(string w in words){
            if(!stringToId.ContainsKey(w)){
                stringToId.Add(w, id++);
            }
        }
        
        return stringToId;
    }
    
    Dictionary<int, int> GetWordIdsFrequencies(string[] words, Dictionary<string, int> wordToId) {
        Dictionary<int, int> result = new Dictionary<int, int>();
        
        foreach(var word in words) {
            var wordId = wordToId[word];
            if(!result.ContainsKey(wordId)){
                result[wordId] = 1;
            } else {
                result[wordId]++;
            }
        }
        
        return result;
    }
}