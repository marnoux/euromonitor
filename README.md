# Euromonitor Assessment Project

This is my assessment project for a position at  **Euromonitor**. Below you can find a short description of the project along with instructions on how to install and run the project.


# Goals 
The goal of the assessment was to determine the following: 

 - [x] Application Architecture
 - [X] Engineering practices and coding standards
 - [X] The use of the technology listed in the technology stack bellow
 - [X] Adhering to industry standards and best practice

# Technology Stack 
- .Net Framework 
- Asp.Net Core
- C#
- Angular 
- Node JS
- Swagger

# Installation Instructions
Dependencies

 - [.NET 5.0.9 SDK](https://github.com/dotnet/core/blob/main/release-notes/5.0/5.0.9/5.0.9.md?WT.mc_id=dotnet-35129-website)
 - [Angular CLI](https://angular.io/cli)
 - [Node.js](https://nodejs.org/en/) (I used version 14.17.5 but the latest version will be fine)

# Steps

>  #### Open terminal in directory of choice
>  ## Checkout repo
>  git clone https://github.com/marnoux/euromonitor.git
>  cd euromonitor
>  ## Start API
>  cd api
>  dotnet ef database update
>  dotnet watch run
>  #### The API documentation should appear in an open browser window

>  ## Start Client
>  #### Open a new terminal instance in the client directory (As the first one will be used to run the API)
>  npm install
>  ng serve
>  #### In a new browser window, navigate to http://localhost:4200/
>  ## Using the Client
>  Create a test account
>  ![](https://i.imgur.com/uAv2r6s.png)
> Subscribe to some books
> ![enter image description here](https://i.imgur.com/yjfmsUL.png)
> Click on 'Subscriptions' to view your subscribed books
> ![enter image description here](https://i.imgur.com/L7q1cpV.png)
> ### There are also a bunch of functional features in the app that can be tested,  like validations and error handling
> Trying to add an already active subscription![Trying to add an already active subscription](https://i.imgur.com/02SNqce.png)
> Creating a user that already exists
> ![enter image description here](https://i.imgur.com/hyrK0yv.png)
>  ## Using the API
>  I have attached a postman collection that can be used to test the API endpoints.  
>  ![enter image description here](https://i.imgur.com/mne45ZW.png)
> The tokenization is parameterized so you won't have to add it in manually every time
> ![enter image description here](https://i.imgur.com/ltzmzy8.png)

## Please feel free to contact me if you have any questions/issues with  installing and using the app
