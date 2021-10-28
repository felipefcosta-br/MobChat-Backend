using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;

namespace MobChat.Microservices.ChatMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextMessagesController : ControllerBase
    {
        private readonly ITextMessageService textMessageService;

        public TextMessagesController(ITextMessageService textMessageService)
        {
            this.textMessageService = textMessageService;
        }

        // GET: api/TextMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessage()
        {
            return NotFound();
        }

        // GET: api/TextMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextMessage>> GetTextMessage(Guid id)
        {
            var textMessage = await textMessageService.GetTextMessageAsync(id);

            if (textMessage == null)
            {
                return NotFound();
            }

            return textMessage;
        }

        // GET: api/TextMessages/Chat/5
        [HttpGet("Chat/{chatId}")]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessagesByChatIdAsync(Guid chatId)
        {
            var textMessages = await textMessageService.GetTextMessagesByChatIdAsync(chatId);

            if (textMessages == null)
            {
                return NotFound();
            }

            return Ok(textMessages);
        }

        [HttpGet("SenderOrReceiver/{id}")]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessagseBySenderIdOrReceiverIdAsync(Guid id)
        {
            var textMessages = await textMessageService.GetTextMessagseBySenderIdOrReceiverIdAsync(id);

            if (textMessages == null)
            {
                return NotFound();
            }

            return Ok(textMessages);
        }

        [HttpGet("SenderAndReceiver/{senderId}/{receiverId}")]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessagesBySenderIdAndReceiverIdAsync(Guid senderId, Guid receiverId)
        {
            var textMessages = await textMessageService.GetTextMessagesBySenderIdAndReceiverIdAsync(senderId, receiverId);

            if (textMessages == null)
            {
                return NotFound();
            }

            return Ok(textMessages);
        }

        [HttpGet("Sender/{senderId}")]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessagesBySenderIdAsync(Guid senderId)
        {
            var textMessages = await textMessageService.GetTextMessagesBySenderIdAsync(senderId);

            if (textMessages == null)
            {
                return NotFound();
            }

            return Ok(textMessages);
        }

        [HttpGet("Receiver/{receiverId}")]
        public async Task<ActionResult<IEnumerable<TextMessage>>> GetTextMessagesByReceiverIdAsync(Guid receiverId)
        {
            var textMessages = await textMessageService.GetTextMessagesByReceiverIdAsync(receiverId);

            if (textMessages == null)
            {
                return NotFound();
            }

            return Ok(textMessages);
        }

        // PUT: api/TextMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextMessage(Guid id, TextMessage textMessage)
        {

            return NoContent();
        }

        // POST: api/TextMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TextMessage>> PostTextMessage(TextMessage textMessage)
        {
            var result = await textMessageService.AddTextMessageAsync(textMessage);

            if (!result)
                BadRequest("Text Message invalid");

            return Created("api/textmessage", textMessage);
        }

        // DELETE: api/TextMessages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TextMessage>> DeleteTextMessage(Guid id)
        {
            var result = await textMessageService.DeleteTextMessageAsync(id);

            if (!result)
                return NotFound("Profile not found!");

            return Ok(id);
        }

        private bool TextMessageExists(Guid id)
        {
            return false;
        }
    }
}
