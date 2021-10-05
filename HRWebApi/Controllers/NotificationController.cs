using AutoMapper;
using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using HRWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public NotificationController(INotificationService notificationService, IUserService userService, IMapper _mapper)
        {
            this.notificationService = notificationService;
            this.userService = userService;
            this.mapper = _mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationsByUserID(Guid id)
        {
            await notificationService.SetSeenAllNotificationsByUserIDAsync(id); //görüldü yapacak
            List<Notification> notifications = (List<Notification>)await notificationService.GetAllActiveNotificationsByUserIDAsync(id);
            List<NotificationDTO> notificationDTOs = new List<NotificationDTO>();
            foreach (Notification item in notifications)
            {
                User user = userService.GetUserByID(id);
                string fullName = user.FirstName + " " + user.LastName;
                NotificationDTO notificationDTO = mapper.Map<Notification, NotificationDTO>(item);
                notificationDTO.EmployeeName = fullName;
                notificationDTO.CreatedDate = item.CreatedDate;
                notificationDTOs.Add(notificationDTO);
            }
            return Ok(notificationDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationByID(Guid id)
        {
            Notification notification = await notificationService.GetNotificationByIdAsync(id);
            return Ok(notification);
        }
        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationDTO notificationDTO)
        {
            if (ModelState.IsValid)
            {
                notificationDTO.CreatedDate = DateTime.Now;
                Notification notification = mapper.Map<NotificationDTO, Notification>(notificationDTO);
                string error = await notificationService.AddNotificationAsync(notification);
                if (error != null) { return BadRequest(error); }
                return Ok("Notification successfully added!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            await notificationService.DeleteNotificationAsync(id);
            return Ok("Notification is successfully deleted!");
        }
      
    }
}
