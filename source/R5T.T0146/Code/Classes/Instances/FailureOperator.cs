using System;


namespace R5T.T0146
{
	public class FailureOperator : IFailureOperator
	{
		#region Infrastructure

	    public static IFailureOperator Instance { get; } = new FailureOperator();

	    private FailureOperator()
	    {
        }

	    #endregion
	}
}