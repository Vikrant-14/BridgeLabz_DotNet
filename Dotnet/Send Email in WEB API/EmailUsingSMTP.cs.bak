Email: 
------

Dependency : MailKit
Ethereal : Fake SMTP Email service

private readonly IEmailService _emailService;

public EmailController(IEmailService emailService){
	_emailService = emailService;
}

public IActionResult SendEmail(EmailML model){
	_emailService.SendEmail(model);
	
	return Ok();
}



DTO : 
-----
public class EmailML{
	public string To { get; set; } = string.Empty;
	public string Subject { get; set; } = string.Empty;
	public string Body { get; set; } = string.Empty;
}

InterFace: 
----------
public interface IEmailService{
	public void SendEmail(EmailML model);
}

Service : 
--------
public class EmailService : IEmailService{
	
	private readonly IConfiguration _config;
	
	public EmailService(IConfiguration config){
		_config = config;
	}
	
	public void SendEmail(EmailML model){
		var email = new MimeMessage();
	
		email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
		email.To.Add(MailboxAddress.Parse(model.To));
		email.Subject = model.Subject;
		email.Body = new TextPart(TextFormat.HTML){
			Text = model.Body; //reset password api //url
		};
		
		using var smtp = new SmtpClient();
		smtp.Connect(_config.GetSection("EmailHost").Value,587, SecureSocketOptions.StartTls);
		smtp.Authenticate(_config.GetSection("EmailUsername").Value,_config.GetSection("EmailPassword").Value);
		smtp.Send(email);
		smtp.Disconnect(true);
	}
}

appsettings.json : 
------------------
{
	"EmailHost" : "smtp.gmail.com",
	"EmailUsername" : "vikrantgawale123@gmail",
	"EmailPassword" : "8452026698"
}

==========================
forget password :
-----------------
1. input : user email
2. find user using email
3. generate token
4. Send email including token

reset api : 
----------
1. find user with the help of token
1. update new password 