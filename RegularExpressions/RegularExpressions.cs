using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool IsMatch(string s, string p) {
        
        if(string.IsNullOrWhiteSpace(p))
            return s == p;
        
        var (stateToDescriptions, acceptingStates) =  BuildStateMachine(p);
        
        foreach(var kvp in stateToDescriptions){
            Console.WriteLine("State " + kvp.Key);
            foreach(var sn in kvp.Value.CharToStates){
                Console.WriteLine("     " + sn.Key);
                foreach(var sv in sn.Value){
                    Console.WriteLine("         " + sv);
                }
                
            }
        }
        
        foreach(var ac in acceptingStates) {
            Console.WriteLine(ac);
        }
        
        
        List<int> currentStates = new List<int>() { 0 };
        foreach(var ch in s) {
            
            List<int> nextStates = new List<int>();
            foreach(var state in currentStates) {
                var stateInfo = stateToDescriptions[state];
                var transitionStates = stateInfo.GetTransitions(ch);
                nextStates.AddRange(transitionStates);
            }
            
            if(nextStates.Count == 0){
                return false;
            }
            
            currentStates = nextStates.Distinct().ToList();
            
            Console.WriteLine("Char States for:  " + ch);
            foreach(var state in currentStates){
                Console.WriteLine("         " + state);
            }
        }
        
        foreach(var state in currentStates) {
            if(acceptingStates.Contains(state))
            {
                return true;
            }
        }
        
        return false;
    }
    
    class StateInfo {
        
        public int Id;
    
        public bool Optional;
    
        public Dictionary<char, List<int>> CharToStates = new Dictionary<char, List<int>>();
        
        public void AddTransition(char ch, int nextState) {
            if(!CharToStates.ContainsKey(ch))
                CharToStates[ch] = new List<int>();
            
            CharToStates[ch].Add(nextState);
        }
        
        public List<int> GetTransitions(char ch){
            
            List<int> result = new List<int>();
            if(CharToStates.ContainsKey(ch))
            {
                result.AddRange(CharToStates[ch]);
            }
            
            if(CharToStates.ContainsKey('.'))
            {
                result.AddRange(CharToStates['.']);
            }
            
            return result.Distinct().ToList();
        }
    }
    
       
    private (Dictionary<int, StateInfo>, HashSet<int>) BuildStateMachine(string p)
    {
        List<StateInfo> states = new List<StateInfo>();
        
        StateInfo prevState = new StateInfo() { Id = 0 };
        states.Add(prevState);
      
        var isntructions = GetInstructionTokens(p);
        
        // Calculating basic transitions
        foreach(var inst in isntructions)
        {    
            var currentState = new StateInfo { Id = prevState.Id + 1 };
            
            if(!inst.StartsWith('*'))
            {
                var ch = inst[0];
                prevState.AddTransition(ch, currentState.Id);
            }
            else 
            {
                var ch = inst[1];
                currentState.Optional = true;
                prevState.AddTransition(ch, currentState.Id);
                currentState.AddTransition(ch, currentState.Id);
            }
            
            states.Add(currentState);      
            prevState = currentState;
        }
        
        // Adding shortcuts for optional nodes
        for(int i = states.Count-1; i > 0 ; i--){
            var state = states[i];
            if(state.Optional) {
                var previousState = states[i-1];
                
                foreach(var transition in state.CharToStates){
                    bool loopTransition = transition.Value.Count == 1 && transition.Value[0] == state.Id;
                    if(!loopTransition){
                        foreach(var nextState in transition.Value){
                            previousState.AddTransition(transition.Key, nextState);
                        }
                    }
                }
            }
        }
        
        states.Add(new StateInfo() { Id = states.Last().Id + 1, Optional = true });
        
        
        HashSet<int> acceptingStates = new HashSet<int>();
        // Expecting that state machine can be inside c* rule
        for(int i = states.Count-1; i >= 0 ; i--)
        {
            var state = states[i];
            acceptingStates.Add(state.Id);
            if(!state.Optional) {
                break;
            }
        }
            
        return (states.ToDictionary(s => s.Id, s => s), acceptingStates);
    }
    
    private string[] GetInstructionTokens(string p) {
        
        var instructionStack = new Stack<string>();
        // Parsing tokens
        foreach(var ch in p) {
            if(ch != '*') {
                instructionStack.Push($"{ch}");
            }
            else {
                var symbol = instructionStack.Pop();
                instructionStack.Push($"*{symbol}");
            }
        }
        
        return instructionStack.Reverse().ToArray();
    }
}