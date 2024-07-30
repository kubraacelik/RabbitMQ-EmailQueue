# RabbitMQ Email Sending System

This project presents a system that uses RabbitMQ to queue e-mail messages and send e-mails from this queue. The project consists of two main components: a producer and a consumer.

## Producer

**Purpose:** Sends email messages to the RabbitMQ queue.

**How it works:**
1. Connects to the RabbitMQ server.
2. Creates a queue named `mail-queue`.
3. Prepares `MessageModel` objects containing e-mail addresses and message contents.
4. Sends each `MessageModel` object in JSON format to the queue.

## Consumer

**Purpose:** Retrieves messages from the RabbitMQ queue and sends e-mails.

**How it works:**
1. Connects to the RabbitMQ server.
2. Listens for messages from a queue named `mail-queue`.
3. Receives each message from the queue and converts it from JSON format to a `MessageModel` object.
4. Sends an email using the `SendEmail` method.
5. Prints any error messages to the console if there is an issue with sending the email.

## Usage

1. Ensure RabbitMQ server is installed and running.
2. Run the producer script to send email messages to the queue.
3. Execute the consumer code to send emails received from the queue.
4. The project combines a simple email forwarding solution with RabbitMQ's queuing mechanism for efficient communication.

**To open and start RabbitMQ:**
```bash
net start RabbitMQ
