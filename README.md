# Social Media Platform

This project is a social media platform developed using Angular for the frontend and .NET for the backend. It includes features for user engagement score calculation, content moderation, and user feed management.

## Features

- User Engagement Score Calculation
- User Feed
- Post List
- Content Moderation
- User Management

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Components](#components)
  - [User Engagement Component](#user-engagement-component)
  - [User Feed Component](#user-feed-component)
  - [Post List Component](#post-list-component)
  - [Content Moderation Component](#content-moderation-component)
- [Routing Configuration](#routing-configuration)
- [Navbar Integration](#navbar-integration)
- [License](#license)

## Getting Started

Follow these instructions to set up the project on your local machine for development and testing purposes.

## Prerequisites

- [Node.js](https://nodejs.org/) (v16 or later)
- [Angular CLI](https://angular.io/cli) (v17 or later)
- [.NET SDK](https://dotnet.microsoft.com/download) (v6.0 or later)

## Installation

1. *Clone the repository:*

    bash
    git clone https://github.com/your-username/social-media-platform.git
    cd social-media-platform
    

2. *Install the Angular frontend dependencies:*

    bash
    cd frontend
    npm install
    

3. *Set up the .NET backend:*

    bash
    cd ../backend
    dotnet restore
    

## Running the Application

1. *Run the .NET backend:*

    bash
    cd backend
    dotnet run
    

    The backend will start on http://localhost:5182.

2. *Run the Angular frontend:*

    bash
    cd ../frontend
    ng serve
    

    The frontend will be available on http://localhost:4200.

## API Endpoints

### User Management

- *GET /User*

    Returns a list of all users.

    json
    [
        {
            "userID": 1,
            "userName": "Alice",
            "engagementScore": 98
        },
        {
            "userID": 2,
            "userName": "Bob",
            "engagementScore": 23
        }
    ]
    ![GET_POST](https://github.com/user-attachments/assets/526c3ddc-cc0c-4555-bab7-66f0a0870a39)


### User Engagement Scores

- *GET /User/engagement-scores*

    Returns the engagement scores of all users.

    json
    [
        {
            "userID": 1,
            "userName": "Alice",
            "engagementScore": 98
        },
        {
            "userID": 2,
            "userName": "Bob",
            "engagementScore": 23
        }
    ]
    ![User_Engagement_Score](https://github.com/user-attachments/assets/27732cd0-a0ec-4deb-b342-5ea7ff75758a)


### User Feed

- *GET /Feed*

    Returns the user feed.

    json
    [
        {
            "postID": 1,
            "userID": 1,
            "content": "This is a post",
            "likes": 10,
            "comments": 5
        }
    ]
    ![GET_FEED](https://github.com/user-attachments/assets/f87b2186-e9e8-4d08-8930-6e58046afa41)


### Posts

- *GET /Posts*

    Returns a list of posts.

    json
    [
        {
            "postID": 1,
            "userID": 1,
            "content": "This is a post",
            "likes": 10,
ments": 5
        }
    ]

  
    ![GET_POST](https://github.com/user-attachments/assets/80550579-dd35-45fe-b9ad-8b757eec63cd)


### Content Moderation

- *GET /Moderation*

    Returns a list of posts flagged for moderation.

    json
    [
        {
            "postID": 1,
            "userID": 1,
            "content": "This is a flagged post",
            "likes": 0,
            "comments": 0,
            "flagged": true
        }
    ]
    
![GET_COMMENT](https://github.com/user-attachments/assets/d2dda7d6-e492-4cc5-8e3a-d06fcddaf860)

## Components
![Like](https://github.com/user-attachments/assets/ef32719f-a100-47d8-a5bf-2727582ebe25)

![Show_Comment](https://github.com/user-attachments/assets/37473846-fe26-42af-ae6f-78dab42b0604)

![Hide_Comment](https://github.com/user-attachments/assets/14b25341-42ec-4a6a-a482-cf5091dc0061)

![Alert_inappropriate_comment](https://github.com/user-attachments/assets/e3787122-24fe-4aa1-8ebe-ca8e8f20f22b)

![Alert_post](https://github.com/user-attachments/assets/a5d1ac68-ee96-47f9-b6a6-f802d741e963)

![Update_Post](https://github.com/user-attachments/assets/99fb6f31-ba31-413c-a7a9-4c0a960986d2)

![User_Selection](https://github.com/user-attachments/assets/5b551cb7-f782-4bfa-ae1c-15f109538bc8)

![User_Engagement_Score](https://github.com/user-attachments/assets/b354b429-892b-4a12-b1b5-69ff8a066fcc)
