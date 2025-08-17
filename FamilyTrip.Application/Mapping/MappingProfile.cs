using AutoMapper;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.FamilyMember;
using FamilyTrip.Application.DTOs.ItineraryItem;
using FamilyTrip.Application.DTOs.PackingList;
using FamilyTrip.Application.DTOs.Trip;
using FamilyTrip.Application.DTOs.Itinerary;
using FamilyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();           
            CreateMap<ItineraryItem, ItineraryItemDto>()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTime.Today.Add(src.Time)))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId)) // Ensure ItineraryId is mapped
                .ReverseMap()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.TimeOfDay))
                .ForMember(dest => dest.ItineraryId, opt => opt.MapFrom(src => src.ItineraryId)); // Ensure ItineraryId is mapped
            CreateMap<Expense, ExpenseDto>()
                .ForMember(dest => dest.PaidByUserId, opt => opt.MapFrom(src => src.PayerId))
                .ReverseMap()
                .ForMember(dest => dest.PayerId, opt => opt.MapFrom(src => src.PaidByUserId));
            CreateMap<PackingItem, PackingItemDto>()
                .ForMember(dest => dest.PackingListId, opt => opt.MapFrom(src => src.PackingListId));
            CreateMap<PackingItemDto, PackingItem>()
                .ForMember(dest => dest.PackingListId, opt => opt.MapFrom(src => src.PackingListId));
            CreateMap<FamilyMember, FamilyMemberDto>()
                .ForMember(dest => dest.FamilyId, opt => opt.MapFrom(src => src.FamilyId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap()
                .ForMember(dest => dest.FamilyId, opt => opt.MapFrom(src => src.FamilyId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<CreateTripDto, Trip>();
            CreateMap<CreateItineraryDto, Itinerary>();
            CreateMap<CreateItineraryItemDto, ItineraryItem>();
            CreateMap<CreatePackingItemDto, PackingItem>();
            CreateMap<CreateFamilyMemberDto, FamilyMember>();           
            CreateMap<Family, FamilyDto>().ReverseMap();
            CreateMap<CreateFamilyDto, Family>();
            CreateMap<PackingList, PackingListDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<CreatePackingListDto, PackingList>();
        }
    }
}
