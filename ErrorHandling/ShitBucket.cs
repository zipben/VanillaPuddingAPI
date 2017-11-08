using System;
using System.Collections.Generic;

public class ShitBucket{
    public Stack<string> Errors{ get; set; }
    public string Recent { get; set; }
    public bool IsValid { get; set; }

    public ShitBucket(){
        this.Errors = new Stack<string>();
        this.IsValid = true;
        this.Recent = "";
    }

    public void AddError(string error){
        this.Errors.Push(error);
        this.IsValid = false;
    }

    public string GetTopError(){
        string retString = "";

        if(!Errors.TryPop(out retString)){
            return "No Errors Found";
        }

        return retString;
    }

    public void CleanBucket(){
        this.Errors = new Stack<string>();
        this.IsValid = true;
    }
}