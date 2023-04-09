# Lectures
- [Recording Links](https://intellitectsp.sharepoint.com/sites/EWU-CSCD379-2023-Spring2/Shared%20Documents/Forms/AllItems.aspx?csf=1&web=1&e=AlDCxm&OR=Teams%2DHL&CT=1680809170215&clickparams=eyJBcHBOYW1lIjoiVGVhbXMtRGVza3RvcCIsIkFwcFZlcnNpb24iOiIyNy8yMzAzMTkwMTIwNSIsIkhhc0ZlZGVyYXRlZFVzZXIiOmZhbHNlfQ%3D%3D&cid=85dd75ee%2D9b56%2D45dc%2D9f37%2D5cf3d356f9e9&RootFolder=%2Fsites%2FEWU%2DCSCD379%2D2023%2DSpring2%2FShared%20Documents%2FGeneral%2FRecordings&FolderCTID=0x01200091D1690CC994E649B359E631917B2388)
- This is an MS Teams link and everyone in the class should have access. If not, please contact an instructor.

## Tentative Lecture Schedule

## Week 1
### Lecture 1: 4/4: Build the App (Assignment 1)
- Syllabus & expectations
- Wordle Requirements
- Set up front end and build out basic application. 
- Initial look at 
  - NPM
  - Vue
  - Vuetify
- Basic unit testing with Jest


### Lecture 2: 4/6: Deployment (Assignment 1)
- Complete application 
- Build deployment for front-end in Azure.
- Azure DevOps
- YAML
- Azure AppService
- Vue Build

## Week 2
### Lecture 3: 4/11: Vue (Assignment 2)
- Why Vue? What problem does is solve?
- What is Vue for and how does it work? Stop messing with the DOM
- {{ Interpolation }}
- Data Binding and Observables: https://vuejs.org/guide/essentials/template-syntax.html
  - Proxies
  - Attributes
  - Class and Style https://vuejs.org/guide/essentials/class-and-style.html
  - Functions
  - Conditional Rendering: https://vuejs.org/guide/essentials/conditional.html
  - Lists (For loops): https://vuejs.org/guide/essentials/list.html
  - Events: https://vuejs.org/guide/essentials/event-handling.html
  - Input: https://vuejs.org/guide/essentials/forms.html
- Computed properties https://vuejs.org/guide/essentials/computed.html
- Pages
- Component Basics
- Routing https://vuejs.org/guide/scaling-up/routing.html
- Lifecycle: https://vuejs.org/guide/essentials/lifecycle.html


### Lecture 4. 4/13: Vuetify (Assignment 2)
- Why CSS is the devil
- Grid System
- Display and sizing
- Icons
- Theming
- Elevation
- Height and width (h- & w-"
- Spacing (padding and margins) (CSS Box Model)
- Components: Containment
  - Buttons
  - Cards
  - Chips
  - Lists
- Components: Tables
- Components: Form Inputs
  - Selects
  - Switches
  - Text: Fields and Areas
  - Combos


## Week 3
### Lecture 5. 4/18: Vue Components (Assignment 2)
- Components: https://vuejs.org/guide/components/registration.html
  - Props https://vuejs.org/guide/components/props.html
  - Events https://vuejs.org/guide/components/events.html
  - v-model https://vuejs.org/guide/components/v-model.html
  - Slots https://vuejs.org/guide/components/slots.html
- Watchers: https://vuejs.org/guide/essentials/watchers.html
- Transitions: https://vuejs.org/guide/built-ins/transition.html


### Lecture 6. 4/20: ASP.NET Intro
- Starting an ASP.NET API Project
- Creating a simple API
- Unit Testing the API
- Program.cs
- Controllers
- Services (DI)


## Week 4
### Lecture 7. 4/25: Entity Framework Intro
- Creating a context
- Creating models
- Migrations
- Deployment (Site and Database)


### Lecture 8. 4/27: 
- More ASP.NET and EF


## Week 5
### Lecture 9. 5/2: 


### Lecture 10. 5/4: 


## Week 6
### Lecture 11. 5/9: 


### Lecture 12. 5/11: 


## Week 7
### Lecture 13. 5/16: 


### Lecture 14. 5/18: 


## Week 8
### Lecture 15. 5/23: 


### Lecture 16. 5/25: 


## Week 9
### Lecture 17. 5/30: 


### Lecture 18. 6/1: 


## Week 10 
### Lecture 19. 6/6: 


### Lecture 20. 6/8: 

Other Topics
  - Vuetify
    - Flex
    - Float
    - Dialogs
    - Menus
    - Tooltips
    - 

## Finals Week


# Other Notes from last year's class
## Lectures
### Lecture 8 (4/28/22)
- Finish covering EF
- Unit Testing with EF
- Homework #3
- Review Homework #2 due tonight

### Lecture 7 (4/26/22)
- Complete the Leaderboard API without spilling the beans on Homework #3
- ASP.NET Unit Testing
  - Unit testing the LeaderBoardService
  - Unit testing LeaderboardController
  - Creating a mock for ILeaderBoardService
  - Integration testing the LeaderBoard API endpoints
- Building a Statistics Controller
  - Setting up EF
  - Adding a Context and Statistics class
  - Migrations
- Deploying to Azure with an Azure SQL database
  - Set up Azure SQL Database
  - Set up Connection Strings

### Lecture 6 (4/21/22)
- Creating an API project in C# with .NET 6
- Introduction to APIs and program.cs
- Controllers and Routing (get and post)
- Creating an Azure Web App
- Setting up a CI/CD for the Web App from GitHub
- Adjusting CI/CD with 
- Creating an API for the leaderboard
- Ajusting the action with on: paths: - 'Wordle.api/**' and workflow_dispatch:

### Lecture 5 (4/19/22)
- npm run lintfix & it's importance
- Assignment 2 overview
- Vuetify Components Continued
  - v-dialog
  - v-menu
- Vuetify themes
- router-link
- created/mounted functions

### Lecture 4 (4/14/22)
- Keeping Git Fork in sync with class repo
- Vuetify components
  - v-card
  - v-row
  - v-col
  - v-btn
- Building your own components
- slots
- passing properties
- interacting with your TS within your vue code

### Lecture 3 (4/12/2022)
- TypeScript continued
- Jest Unit Testing
- Introduction to vuetify (More on this in the 4/14 lecture)

### Lecture 2 (4/7/2022)
- Clarify homework and how to do deployments.
- GitHub Actions/Workflows
- Secrets in GitHub
- Deployment Tokens in Azure Static Web Apps
- Why use tokens
- Authentication and authorization
- Introduction to Vue
- Intro to TypeScript

### Lecture 1 (4/5/2022)
- Introduction/Homework
- Create a front end Nuxt app and deploy it to azure
- NPM
- Nuxt
- Github Actions/YAML files
- Azure static web app

### Next Topics (This list is subject to change based on the pace of the class)
- TypeScript: Classes and Testing with Jest (4/7)
- Vue: Components, Events, Properties, Reactivity (4/12)
- Vuetify: Creating user interfaces, Component usage, UI/UX considerations, icons, animation, responsive design, etc. (4/14, 4/19)*
- UI Wrap up (4/21)
- ASP.Net Core API endpoint, Deploying and using the API endpoint (4/26)
- Entity Framework (2/28)*
- Creating an API backed with EF (5/3)
- Authentication (5/5)
- SignalR (5/10-5/12)
- Metrics using Application Insights (5/17)

