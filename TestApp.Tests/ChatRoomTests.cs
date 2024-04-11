using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "katerina";
        string message = "hello";

        // Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("katerina: hello - Sent at "));

    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange
        

        // Act
        
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string sender = "katerina";
        string message = "hello, hi";

        // Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Does.Contain("katerina: hello, hi - Sent at "));
    }
}
