# Babysitter Kata

This is my implementation of the kata for https://github.com/PillarTechnology/kata-babysitter.

One thing to note is that times are represented internally as continuous counts, they do not wrap over at midnight. For example, 1AM is represented as 25 hours.

## Testing

To run this, you need .NET Core 2.2. All other dependencies will be installed from NuGet as normal for .NET Core.

To test, do the following from the project root:

```
PS C:\BabysitterKata> dotnet test
```

This will build the projects and run the test. You should see output like the following:

```
Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 16
     Passed: 16
 Total time: 0.8381 Seconds
```