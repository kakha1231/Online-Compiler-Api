﻿namespace informaticsge.models;

public class ExecutionResult
{

    public bool Success { get; set; }
    
    public int TestCaseNum { set; get; }
    public string? ExpectedOutput { set; get; }
    public string? Error { get; set; }
    public string? Output { get; set; } // Output generated by the compiled code
}