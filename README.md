# Sparta Global Training Final Project: The Trainee Tracker

This project revolves around the creation of self evaluation software for trainees to use throughout the course, with their trainers able to view their data. This is currently handled by Sparta via the use of tracker spreadsheets updated at the end of each week. The project is based around an `Asp.net MVC pattern` with `Javascript` and `css` files added to aid frontend aesthetics.



The current project build delivers a functioning tracker system, seeded with dummy course and trainee data with web forms being added after this setup stage to manage the system. Currently, the system has two main roles:
* Trainer: Able to see all trainees, search for trainees by name or course and see every trainees trackers
* Trainee: only able to see their own trackers



The project has room for additional functionality, such as summary reports and graphs that track weekly scores and show trends over time in order to aid trainers in supporting trainees more effectively. The authentication system used by the project could also be improved to increase data security.

## Installing the Project

To run the project simply download a version of the system off of GitHub, and then follow the following steps:

1) In the project select `Tools` > `NuGet Package Manager` > `Package Manager Console`

   ![image-20220413143709401](Images\PMC.PNG)

2) In the `Package Manager Console` at the bottom of Visual studio run the command `update-database`

![image-20220413144121310](Images\PMC_demo.PNG)

3) You should now be able to run the project from your computer.

If you want to use the program as a Trainer you can use: nish@nish.com

Or to use it as a Trainee use the following: joebloggs@email.com

## How to use the Trainee Tracker







## How Does the Trainee Tracker Work?

> The Database Setup
>
> ASP.net MVC pattern implementation
>
> Testing

### The Database Setup

 The tracker system has a database which contains tables for Trainers, Trainees, and Trackers. This is shown in the ERD below:

![Final_Project_ERD](Images\ERD.png)

### ASP.net MVC pattern implementation

This project uses the ASP .NET Model View controller pattern for its main structure. This is used to decouple the user interface, data and logic to allow for both the separation of concerns as well as allow for simpler development over a longer term. While this method allows for a wide range of functionality, due to the length of time given for the project the code was focused on achieving core functionality above all else.

### Testing

The project has a full NUnit test suite to test functionality as well as the use of Moq for database method testing. 

This entire test suite can be accessed inside visual studio and run simply as NUnit testing.



Credit:

 G.Dogra, S.Moghim, L.Tozer, G.Nunes, S.Lewis, J.Dickson, N.Telfer, M.Dumitriu, A.Khan

Sparta Global 2022