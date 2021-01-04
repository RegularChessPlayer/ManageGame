using ManageGameApi.Controllers;
using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Input;
using ManageGameApi.Domain.Output;
using ManageGameApi.Services.Interfaces;
using ManageGameApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ManageGameApiTest.Controllers
{
    public class FriendControllerTest
    {
        FriendController _controller;
        IFriendService _service;

        public FriendControllerTest()
        {
            _service = new FriendServiceFake();
            _controller = new FriendController(_service);
        }


        [Fact]
        public async Task Get_WhenCalled_ListFriendAsync()
        {
            // Act
            var response = await _controller.GetFriendsAsync();
            var okResult = response.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<FriendDTO>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public async Task Post_WhenCalled_SaveFriendAsync()
        {
            //Asert
            var friendInput = new FriendInput() { Name = "Jhon Al" };
            // Act
            var response = await _controller.PostCreateFriendAsync(friendInput);
            var okResult = response as OkObjectResult;
            // Assert
            var friendDTO = Assert.IsType<FriendDTO>(okResult.Value);
            Assert.Equal(friendInput.Name, friendDTO.Name);
        }

        [Fact]
        public async Task Put_WhenCalled_UpdateFriendAsync()
        {
            //Asert
            long idMock = 103l;
            var friendInput = new FriendInput() { Name = "New Name" };
            // Act
            var response = await _controller.PutAsync(idMock, friendInput);
            var okResult = response as OkObjectResult;
            // Assert
            var friendDTO = Assert.IsType<FriendDTO>(okResult.Value);
            Assert.Equal(friendInput.Name, friendDTO.Name);
        }

        [Fact]
        public async Task Delete_WhenCalled_DeleteFriendAsync()
        {
            //Asert
            long idMock = 103l;
            // Act
            var response = await _controller.DeleteAsync(idMock);
            var okResult = response as OkObjectResult;
            // Assert
            var friendDTO = Assert.IsType<FriendDTO>(okResult.Value);
            Assert.Equal(idMock, friendDTO.Id);
        }



    }
}
