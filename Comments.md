As the method of submission isn't tied to the type of application, you have to inject each service into ProductApplicationService despite only needing one for a given request.

If we needed to introduce a new type of Application, or remove an existing Application, we would have to continuously go back to modifying the SubmitApplicationFor method which violates the open closed principle. If we instead have a way of tying the submission method to an interface which a given Application implements, we will then be able to call the Submit behaviour without iterating through the different Application types.

The Company Data retrieval and Loans Request retrieval process should be separated out into their own individual functions to make them more easily testable and reusable.

There is no data validation happening on the setting of Company and Loan Data. Though it's not clear what rules should be in place one that's obvious is not allowing a Company Founded Date to be a date in the future. In addition I think the setting of Company Data specifically is too lenient, and it's very easy for this data to get in to a valid state, this could be solved through use of constructors which will force you to specify certain parameters.

The Success/Fail determination is a bit hard to read, instead of working with literal integers I would use enumerations where possible to more clearly define the meaning of the numbers.