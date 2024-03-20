using System;
using System.Collections.Generic;
using Azure;
using Azure.Communication.Email;

// This code retrieves your connection string from an environment variable.
string connectionString = "endpoint=https://notificationservicedemo.unitedstates.communication.azure.com/;accesskey=ihJYTq2ED4+kCSImDJOF5sBA81UIb4MrCRzIhg+RIphKR+5ayQ8f/m7vVR+frT3iE8Gw6t8VZjT7TxLQnGIZYw==";
var emailClient = new EmailClient(connectionString);


EmailSendOperation emailSendOperation = emailClient.Send(
    WaitUntil.Completed,
    senderAddress: "DoNotReply@f48f6b1c-4be0-4419-a3a8-02e2002efc81.azurecomm.net",
    recipientAddress: "rcvishnuvardhan@gmail.com",
    subject: "Test Email",
    htmlContent: "<html><h1>Hello world via email.</h1l></html>",
    plainTextContent: "Hello world via email.");

var result = emailSendOperation;