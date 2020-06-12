public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        
        List<string> results = new List<string>();
        
        Dictionary<int, HashSet<string>> levelToStrings = new Dictionary<int, HashSet<string>>();
        
        levelToStrings[1] = new HashSet<string>(new List<string> { "()"});
        
        for(int i = 2; i <= n; i++){
            
            var result = new HashSet<string>();
            var half = (i + 1) / 2;
            
            // We do split number e.g. 5 to 1-4, 2-3
            for(int j = 1; j <= half; j++)
            {
                var levelMinusj = i - j;
                
                foreach(var combinationMinusJ in levelToStrings[levelMinusj]) {

                    if(j == 1) {
                        result.Add($"({combinationMinusJ})");    
                    }
                    foreach(var combinationJ in levelToStrings[j])
                    {
                        result.Add($"{combinationJ}{combinationMinusJ}");
                        result.Add($"{combinationMinusJ}{combinationJ}");
                    }           
                }
            }
            
            levelToStrings[i] = result;
        }
        
        return levelToStrings[n].ToList();
    }
}