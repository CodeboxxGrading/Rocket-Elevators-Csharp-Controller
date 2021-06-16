# Rocket-Elevators-Csharp-Controller
This is the template to use for the C# commercial controller. In the Commercial_Controller folder, you will find the classes that should be used along with some methods described in the requirements. The necessary files to run some tests are also included, in the Commercial_Controller.Tests folder.

### Installation

As long as you have **.NET 5.0** installed on your computer, nothing more needs to be installed:

The code to run the scenarios is included in the Commercial_Controller folder, and can be executed there with:

`dotnet run <SCENARIO-NUMBER>`

### Running the tests

To launch the tests, make sure to be at the root of the repository and run:

`dotnet test`

With a fully completed project, you should get an output like:

![Screenshot from 2021-06-15 17-31-02](https://user-images.githubusercontent.com/28630658/122128889-3edfa500-ce03-11eb-97d0-df0cc6a79fed.png)

You can also get more details about each test by adding the `-v n` flag: 

`dotnet test -v n` 

which should give something like: 

![Screenshot from 2021-06-15 18-00-52](https://user-images.githubusercontent.com/28630658/122129140-a8f84a00-ce03-11eb-8807-33d7eab8c387.png)

Make sure to only edit files in the Commercial_Controller folder. The test and scenarios files can be left in your final project. The grader will run tests similar to the ones provided.

Of course, make sure to edit this Readme file to describe your own project!
