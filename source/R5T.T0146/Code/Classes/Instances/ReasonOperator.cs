using System;


namespace R5T.T0146
{
	public class ReasonOperator : IReasonOperator
	{
		#region Infrastructure

	    public static IReasonOperator Instance { get; } = new ReasonOperator();

	    private ReasonOperator()
	    {
        }

	    #endregion
	}
}