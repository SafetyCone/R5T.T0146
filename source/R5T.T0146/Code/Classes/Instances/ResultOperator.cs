using System;


namespace R5T.T0146
{
	public class ResultOperator : IResultOperator
	{
		#region Infrastructure

	    public static ResultOperator Instance { get; } = new();

	    private ResultOperator()
	    {
        }

	    #endregion
	}
}