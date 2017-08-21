# FeedbackReviewer
A RESTful Tool for capturing performance feedback running on a .NET stack with a MS Sql server backend.

# Hosted on AWS
http://kaosnyrb.com/RewardTest/swagger/ui/index


# Technolgies used

ASP.NET Web API

    Web API makes it easy to create new web services and plays nicely with MS SQL

MS SQL

    Reliable place to store data. Data is relational so a sql database makes the most sense.

IIS

    Easiest way to host Web API projects

Swagger/Swashbuckle

    Smart tooling that allows easy exploring of endpoints and data models. Very useful for implementing services.

# Model Design

	Employee:
		ID
		Name

	Review (Including feedback):
		ID
		Feedback

    Assignment link between Employee it's for and the review:
		ID
		Reviewing Employee ID
		Review ID

# Endpoints
    Employee:
		GetAll
		Get
		Post
		Put
		Delete

	Review:
		GetAll
		Get
		Put
		Post

	Assignments:
		Get (For employee)
		Get (By Assignment Id)
		Post (For Admin to assign reviews)

