# RabbitMQ Email Sending System
This project presents a system that uses RabbitMQ to queue e-mail messages and sends e-mails from this queue. The project has two main components: a producer and a consumer.

## Producer
Purpose: Sends email messages to the RabbitMQ queue.
How it works:
Connects to the RabbitMQ server.
Creates a queue named mail-queue.
Prepares MessageModel objects containing e-mail addresses and message contents.
Sends each MessageModel object in JSON format to the queue.

## Consumer
Purpose: Retrieves messages from the RabbitMQ queue and sends e-mail.
How it works:
Connects to the RabbitMQ server.
Listens for messages from a queue named mail-queue.
Receives each message from the queue, converts it from JSON format to MessageModel object.
Sends an email using the SendEmail method.
If there is an error in sending the email, it prints the error message to the console.

## Usage:
RabbitMQ server must be installed and running.
Email messages are sent from the queue by running the producer script.
Consumer code is executed to send emails received from the queue.
The project provides efficient communication by combining a simple email forwarding solution with RabbitMQ's queuing mechanism.

-To open and start Rabbitmq, enter this command: net start RabbitMQ
-Connect to the RabbbitMQ interface at http://localhost:15672
-First, start EmailQueue by selecting Debug->Start New Instance
-Select Queues and Streams at http://localhost:15672 and refresh 
-Then run Consume-Queue and send messages to emails
