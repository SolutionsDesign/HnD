<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<%@ Page language="c#" CodeFile="RegistrationRules.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.RegistrationRules" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Registration terms</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

</head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Registration terms</h3>
		<p>
			While the administrators and moderators of this forum will attempt to remove or 
			edit any generally objectionable material as quickly as possible, it is 
			impossible to review every message. Therefore you acknowledge that all posts 
			made to these forums express the views and opinions of the author and not the 
			administrators, moderators or webmaster (except for posts by these people) and 
			hence will not be held liable.
		</p>
		<p>
			You agree not to post any abusive, obscene, vulgar, slanderous, hateful, threatening, 
			sexually-orientated or any other material, including links to pirated software or related to
			pirated software, that may violate any applicable laws. 
			Doing so may lead to you being immediately and permanently banned (and your service provider being 
			informed). The IP address of all people posting in forums on this forum system is logged to aid in 
			enforcing these conditions. 
		</p>
		<p>
			You agree that the webmaster, administrator and moderators of this 
			forum system have the right to remove, edit, move or close any topic at any time should 
			they see fit. As a user you agree to any information you have entered in the registration form, or
			in the profile editing form, being stored in a database. While this information will not be 
			disclosed to any third party without your consent the webmaster, administrator and moderators 
			cannot be held responsible for any hacking attempt that may lead to the data 
			being compromised.
		</p>
		<p>
			This forum system uses cookies to store information on your local computer. 
			These cookies do not contain any of the information you have entered when you registered nor when you edited
			your profile or any information related to your postings on this board, they serve only to improve your 
			viewing pleasure. The email address is used only for sending you your initial password (and for sending new 
			passwords should you forget your current one) as well as notification emails of new posts in threads, if you've
			subscribed to these threads.
		</p>
		<p>
		By registering at this forum system, you agree with these registration terms.
		</p>
		<center>
			<a href="javascript://" onclick="window.close();">Close window</a>
		</center>
		<br>
	</td>
</tr>
</table>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
