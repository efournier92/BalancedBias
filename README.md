# ![BalancedBias](https://github.com/efournier92/balancedbias/blob/master/Web/Media/img/logo/BalancedBias_Logo_Dark.png?raw=true)

## Contents
- [Overview](#overview)
- [Demo](#demo)
- [Features](#features)
- [Development Philosophy](#development-philosophy)
- [Stack](#stack)
- [Configuration](#configuration)
- [Building](#building)
- [Contributing](#contributing)
- [Licensing](#licensing)
- [Features To Do](#features-to-do)

## Overview
In these politically-polarizing times, a having balanced diet of news to ingest is more important than ever. Since most news outlets also provide an RSS feed, this app leverages those as its data source. Seven media channels are displayed by default, ranked them from most liberal to most conservative, laid out from left to right. The result provides insight into how different outlets are covering the same story, at the same time. All articles are persisted to a T-SQL database, such that historical data will be persisted, and further insight can be gained by tracking a news story by keyword over time. This app aims to help balance the media consumption of users everywhere.

## Demo
[BalancedBias](http://balancedbias.gearhostpreview.com/)

## Features

### View News By Media Bias
![News Dashboard](https://github.com/efournier92/balancedbias/blob/master/Web/Media/img/ScreenShots/BalancedBias_NewsDashboard.png?raw=true)

### View History By Date
![Dates Screen](https://github.com/efournier92/balancedbias/blob/master/Web/Media/img/ScreenShots/BalancedBias_DatesDropdown.png?raw=true)

## Development Philosophy
In addition to providing the high-level functionality described in [Overview](#overview), I also wanted to develop this application using a very specific stack. I currently work as a .NET developer on a large WebForms application. Since much of this platform was built before I joined, there were numerous aspects I'm competent in plugging into, but had never built myself from scratch. In designing this application, rather than referencing online resources, I referenced the codebase of the project I work on professionally. Hence giving it a traditional WebForms look, which feels at least a decade behind anything I've developed previously. That said, this project gave me an excellent excuse to grow more accustomed to WebForms patterns, and to practice building certain .NET patterns from the ground up.

## Stack
- ASP.NET 4.7
- T-SQL
- JQuery
- Bootstrap

## Configuration

### `/Web/BalancedBias/App_Config/_BASE/rssChannelsService.config`

#### Add new feed elements, in the following format
```xml
<add name="" url="" icon="" template="GenericArticleTemplate" />
```

## Building
- Open in Visual Studio 2012
- Build the solution
- Configure the application to be hosted under IIS

## Contributing
If you have feature suggestions, please contact me here or at efournier92@gmail.com. If you'd like to submit a pull request, please feel free to, and I'll review merge it at my earliest convenience!

## Licensing
This project is provided under the `MIT` licence and I hereby grant rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the software without limitation, provided the resulting software also carries the same open-source licensing statement.

## Features To Do
- [X] Fix scroll centering on post-back
- [ ] Add caching
- [ ] Add user authentication
- [ ] Add session management
- [ ] Add user ability to define custom news feeds

