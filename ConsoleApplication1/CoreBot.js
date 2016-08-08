var Discord = require("discord.js");

var bot = new Discord.Client();
var banned = [""];

function containsObject(obj, list) {
    var i;
    for (i = 0; i < list.length; i++) {
        if (list[i] === obj) {
            return true;
        }
    }

    return false;
}
function unban(user) {
    var index = banned.indexOf(user);
    banned.splice(index, 1);
}
function ban(user) {
    banned.push("ldrpc");
}

bot.on("message", function (message) {

    if (message.content === "fuck") {
        bot.deleteMessage(message, 10);
        bot.reply(message, "Please do not Use Profane Language");
        banned.push(message.author.username);
        setTimeout(function () { unban(message.author.username); }, 15000);
    }
    if (containsObject(message.author.username, banned) === true && message.channel.isPrivate == false) {
        bot.deleteMessage(message, 10);
        bot.sendMessage(message.author, "You are currently banned");
    }
});

bot.login("luisdanielrodas@hotmail.com", "salami");
