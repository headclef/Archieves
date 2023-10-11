using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<UserViewModel>> AddUserAsync(UserAddModel model)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = _mapper.Map<User>(model);
                var insertResult = await _userRepository.AddAsync(user);
                var userViewModel = _mapper.Map<UserViewModel>(insertResult);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<UserViewModel>> DeleteUserAsync(int id)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user is null)
                {
                    return result.Fail($"No user found with id {id}.");
                }
                var deleteResult = await _userRepository.DeleteAsync(user);
                var userViewModel = _mapper.Map<UserViewModel>(deleteResult);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<List<UserViewModel>>> GetAllUsersAsync()
        {
            var result = new ModelResponse<List<UserViewModel>>();
            try
            {
                var user = _userRepository.GetAllQuery().ToList();
                var userViewModel = _mapper.Map<List<UserViewModel>>(user);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<UserViewModel>> GetUserByEmailandPasswordAsync(UserViewModel model)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = _userRepository.GetAllQuery().FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                if (user is null)
                {
                    return result.Fail($"No user found with email {model.Email}.");
                }
                var userViewModel = _mapper.Map<UserViewModel>(user);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<UserViewModel>> GetUserByEmailAsync(string email)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = _userRepository.GetAllQuery().FirstOrDefaultAsync(x => x.Email == email);
                if (user is null)
                {
                    return result.Fail($"No user found with email {email}.");
                }
                var userViewModel = _mapper.Map<UserViewModel>(user);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<UserViewModel>> GetUserByIdAsync(int id)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user is null)
                {
                    return result.Fail($"No user found with id {id}.");
                }
                var userViewModel = _mapper.Map<UserViewModel>(user);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<UserViewModel>> UpdateUserAsync(UserUpdateModel model)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = _mapper.Map<User>(model);
                var updateResult = await _userRepository.UpdateAsync(user);
                var userViewModel = _mapper.Map<UserViewModel>(updateResult);
                return result.Success(userViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
    }
}