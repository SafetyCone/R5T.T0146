using System;


namespace R5T.T0146
{
	public class FailureOperator : IFailureOperator
	{
		#region Infrastructure

	    public static FailureOperator Instance { get; } = new();

	    private FailureOperator()
	    {
        }

	    #endregion
	}
}