HnD
===

HnD is a Customer Support system, integrating helpdesk features and forums, and was built as an example of what you can do with LLBLGen Pro.

HnD stands for Help and Discuss and starting with v3, it is running on .Net core 3.1+ with 100% LLBLGen Pro code. It offers site owners a flexible and fast customer support system with, among other features: email notification, attachments, secure forums so only the topicstarter and people with a given action right can see / access the thread, search etc. etc. It's open source and you can download it for free.

To see HnD  in action, go to [https://www.llblgen.com/tinyforum](http://www.llblgen.com/tinyforum) (this site will be migrated to v3 a.s.a.p.)

## Requirements 
* Asp.net core MVC 3.1+
* SQL Server 2008 or higher
* .Net core 3.1+

## Development
Development requires any IDE/Editor capable of editing C#/Asp.net core MVC files. To generate the data-access code, you need [LLBLGen Pro v5.7](https://www.llblgen.com/) or later.

## Features
* Strong Markdown support using an extended MarkdownDeep parser. 
* Unlimited forums can be organised into as many sections as you like.
* Both public and private forums and those only for specified user groups.
* Queueing facility for support teams, enabling claiming questions and moving threads between queues.
* Attachment approval system for moderators.
* Editing all messages, editing thread properties and closing and moving threads for moderators.
* Powerful search facility.
* Message quoting, code display/formatting, attachments and automatic URL linking.
* Email notification of replies to your topics.
* Secure forum, user and group permission management.
* Allow limited access to viewing, posting, replying, marking threads as 'done', thread memos and many other options.
* Unlimited members.
* Personal profile creation and management.
* Administration centre with forum and section setup, complete group and member management, extensive ban management, support queue management, 
role management, mass emailing of groups and users by the administrator and many other options.
* Complete control of fonts and colours with cascading style sheets (CSS).
* Responsive design

## Installation
The installation of HnD v3 contains several steps, these are described below

### Database 
To install the database, load the `FullInstall_HnD.sql` file from the SQLScripts folder in this repository into SMSS or other query app that can execute sql queries on SQL Server. 
It'll create the tables, indexes and install stored procedure. The only configuration you have to do is to name the catalog at the code around line 221. If `HnD` is fine, 
you can leave it, if not, you have to rename it there and also the using statement below it. After that, execute the script. It should create a new catalog. 

### ASP.NET Core app
To install the asp.net core app side, first compile it. Load the `HnD.sln` in your favorite IDE and build it. The GUI is the `GuiCore` project, which is the asp.net core app
you'll run. Before doing that you need to configure the `appsettings.json` file. During development you likely want to use user secrets for the settings which have `REMOVE_ME_AFTER_SETTING_UP_STRING_IN_PROD` in their name. See `dotnet user-secrets` for details in the .net core documentation. 

The `appsettings.json` file has two parts which are important, the `HnD` part and the `LLBLGenPro` part. The settings of both parts are described below. 

#### HnD section

- **VirtualRoot**. This is the path fragment between the domain name and the root of the HnD site. If you host the HnD site on its own (sub)domain, this should be `/`. If you
host HnD on a subapplication within a website, e.g. `Forums` (example.dom/Forums), set VirtualRoot to `Forums/`.
- **DefaultFromEmailAddress**. The default email address which is used as 'from' address in all emails HnD sends. 
- **DefaultToEmailAddress**. The default email address which is used as 'to' address in all emails HnD sends, if multiple recipients are receiving the email (e.g. new 
message notifications), as these recipients are specified as Bcc recipients. 
- **SiteName**. This is the name of the system which is used on the start page and in emails
- **EmailPasswordSubject**. The subject to use for emails with the initial generated password
- **EmailThreadNotificationSubject**. The subject to use for emails which are send as notifications for when a new post is posted in a thread a user is subscribed to
- **PasswordResetRequestSubject**. The subject to use for emails which are send to a user if they want to reset their password.
- **EmojiFilesPath**. The path to the emoji image files, relative to wwwroot. 
- **MaxAmountMessagesPerPage**. The maximum amount of messages on a page in a thread page. If a thread has more messages, paging is used. 
- **DataFilesPath**. The path to the folder, relative from the app root folder, which contains some data files for the system, like the email templates and the noise words text file
which is used for filtering out noise words in search queries.
- **MaxNumberOfMinutesToCacheSearchResults**. Search results are cached, and for how long is configurable with this setting.
- **SmileyMappings**. Here you can map shortcuts to emoji names to make typing typical smileys easier. 
- **ResultsetCacheConfiguration**. The resultset cache configuration for resultsets retrieved from the database. 
- **SmtpConfiguration**. The configuration of the SMTP server which is used to send emails. 

#### LLBLGen Pro section

- **CatalogNameOverwrites**. If you have installed the tables etc. into a catalog called `HnD`, you should remove the `CatalogNameOverwrites` section completely. If you have
installed the tables etc. in a catalog named other than `HnD`, specify that name at the spot that says `YourCatalogName`. At runtime LLBLGen Pro will then use that name for 
the catalog instead of `HnD`.
- **SqlServerDQECompatibilityLevel**. The SQL Server compatibility level to use. Unless you're running the forum on SQL Server 2005 or earlier, leave this at the default: 6.


#### Connectionstrings.

To specify the connection string, specify the right server and catalog as well as credentials in the string in the section `ConnectionStrings`. 

#### Building and running

To build the system, simply build the solution. To run it, use `dotnet run` or `dotnet watch run` on the command line inside the `GuiCore` project. To host the forum in 
IIS, you should follow the asp.net core documentation how to host an asp.net core app inside IIS. 

HnD was development on Windows, but should work fine on Linux as well. 

### License
HnD is (c) [Solutions Design bv](https://www.sd.nl) and is released under [the GPL v2 license](https://github.com/SolutionsDesign/HnD/blob/master/LICENSE.txt)

