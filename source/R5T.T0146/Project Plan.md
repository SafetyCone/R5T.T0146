# R5T.T0146
A hierarchical results type library.

## Goals

* Improvement on [FluentResults][1] as a base implementation.
* Hierarchical results tree
* Explicit HasValue() infrastructure, independent of success or failure.
* Titled results (not named, since name has identity implications, but title is merely descriptive).

## Key Ideas

* Separate Result from Reason. A result can have multiple success reasons and failure reasons.
* Hierarchical result tree. Results can have component-results. Final result hierarchy structure is more like a log.
* Component result failures do *not* automatically cause a result to be a failure. Only the reasons of a result do that (like in FluentResults).
* Explicit HasValue() infrastructure, independent of success or failure.
* Titled
* For a result, a success would occur if a component result succeeded. A success reason has no internal reasons; the internals of a success would be reasons of a component result within the result. This success for the result is just that the component result succeeded. (This is somewhat an effort issue, because there are so many successes in a call graph.)
* On the other hand, a failure has internal failure reasons. (This is easier effort-wise, since there are only a few, or is only one, failure in a call graph.)
	* Yes, in 
* Results can be serialized to a foldably-explorable file format (like JSON, or XML) to allow hierarchical investigation.


## Differences from FluentResults

* ISuccess and IFailure, not ISuccess and IError
* Result is sealed.
* Result *also* has metadata, not just reason.


## Conserved ideas from FluentResults

* Separation of Result and Reason.
* IReason
	* Message
	* Metadata dictionary on IReason as Dictionary<string, object>.
* Recursive failure reasons for failures, no recursive reasons for successes. (Those would just be component results. The idea is to have )
* CausedBy() functionality for
* One failure reason causes a result to be evaluated as a failure.
* Result has both value-less Result, and valued Result<TValue>.
* Result is not meant to be inherited.
* Reason is meant to be inherited.


## Prior Work

* R5T.NG0001.Q000 - FluentResults explorations.
* R5T.Magyar
	* R5T.Magyar.Result<T>
	* R5T.Magyar.ActionResult


[1]: https://github.com/altmann/FluentResults