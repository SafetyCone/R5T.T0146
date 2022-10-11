using System;


namespace R5T.T0146
{
	public class ResultOperator : IResultOperator
	{
		#region Infrastructure

	    public static IResultOperator Instance { get; } = new ResultOperator();

	    private ResultOperator()
	    {
        }

	    #endregion
	}
}