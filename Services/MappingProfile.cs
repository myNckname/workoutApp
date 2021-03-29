using AutoMapper;
using Core.Dtos;
using DAL.Models;

namespace Services
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Workout, WorkoutDto>();
            CreateMap<UserWorkout, UserWorkoutDto>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Workout.Title));

            CreateMap<UserWorkoutDto, UserWorkout>();
            CreateMap<Statistics, StatisticsDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(d => d.BodyType, o => o.MapFrom(s => s.UserProfile.BodyType))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.UserProfile.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.UserProfile.LastName))
                .ForMember(d => d.Icon, o => o.MapFrom(s => s.UserProfile.Icon))
                .ForMember(d => d.Weight, o => o.MapFrom(s => s.UserProfile.Weight));
            CreateMap<UserDto, UserProfile>();
        }
    }
}