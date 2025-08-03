# Introduction
This is a project to reproduce the bug is was facing.  

[There is a bug with `.WaitForCompletion(...)` where a project resource will be detected as finished with exit code 0 if there is an exception.](https://github.com/dotnet/aspire/issues/7373)  
To mitigate this bug we added a `try`-`catch`-block to our runner that exits with exit code `-1`.

However, after adding YARP we found that the `WaitForCompletion` is completely ignore if YARP is added as the parent of the resource that is supposed to wait for completion.

# Reproduction
The project as is runs as expected.  
Set `Aspire:YarpAsParent` to true and the web API will not wait for the completion of the runner, it will immediately be started.