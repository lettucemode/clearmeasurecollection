# clearmeasurecollection

Take-home implementation of a collection.

## Thought process

The problem we left off with was to fix the out-of-memory exception that would occur when the function I had calculated the desired array per the requirements.

I couldn't think of a way to do that directly, so I decided to turn the function into a collection that implemented IEnumerable and hide that I was calculating the elements on the fly. I couldn't remember off the top of my head how to implement that, so I consulted this documentation page: https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-8.0

The current implementation requires the user to pass in the inclusive upper bound and a dictionary of `{ int, string }` pairs. If the given number is divisible by one of the keys of the dictionary, the resulting string they get back includes the value. If none of them match, they just get the number back as a string.

I ran into a performance problem when testing my original implementation of that, so I modified it to use `StringBuilder` instead and then included a test to try and stress the string concatenation.

I also included a GitHub action to build the code & run the tests, just for fun.

## Notes

Possible improvement: collection memoizes values that it has seen before. Depends on whether storage space is a factor and how long the collection is expected to live in memory.

An interesting side effect of this implementation is that `collection[-1]` will return a value, but iterating over the entire collection in a loop does not include the negative keys. I think that's fine for now.