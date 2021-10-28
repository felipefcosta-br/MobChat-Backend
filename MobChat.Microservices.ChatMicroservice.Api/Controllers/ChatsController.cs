using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;

namespace MobChat.Microservices.ChatMicroservice.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatsController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        // GET: api/Chats/member/5
        [HttpGet("member/{memberId}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatByMemberId(Guid memberId)
        {
            return Ok(await chatService.GetChatsByMemberId(memberId));
        }

        // GET: api/Chats/members/5/7
        [HttpGet("members/{firstMemberId}/{secondMemberId}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatByMembersId(Guid firstMemberId, Guid secondMemberId)
        {
            return Ok(await chatService.GetChatsByMembersId(firstMemberId, secondMemberId));
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(Guid id)
        {
            var chat = await chatService.GetChatAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(Guid id, Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }

            var result = await chatService.UpdateChatAsync(chat);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // POST: api/Chats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            var result = await chatService.AddChatAsync(chat);

            if (result == Guid.Empty)
                BadRequest("Chat invalid");

            return Created("api/chat", chat);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> DeleteChat(Guid id)
        {
            var result = await chatService.DeleteChatAsync(id);

            if (!result)
                return NotFound("Chat not found!");

            return Ok(id);
        }

        private async Task<bool> ChatExists(Guid id)
        {
            var chat = await chatService.GetChatAsync(id);

            if (chat == null)
            {
                return false;
            }
            return true;
        }
    }
}
