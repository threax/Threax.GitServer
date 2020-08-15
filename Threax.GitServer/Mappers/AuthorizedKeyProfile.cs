using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.GitServer.InputModels;
using Threax.GitServer.Database;
using Threax.GitServer.ViewModels;
using System.Linq;

namespace Threax.GitServer.Mappers
{
    public partial class AppMapper
    {
        public AuthorizedKeyEntity MapAuthorizedKey(AuthorizedKeyInput src, AuthorizedKeyEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public AuthorizedKey MapAuthorizedKey(AuthorizedKeyEntity src, AuthorizedKey dest)
        {
            return mapper.Map(src, dest);
        }

        public IQueryable<AuthorizedKey> ProjectAuthorizedKey(IQueryable<AuthorizedKeyEntity> query)
        {
            return mapper.ProjectTo<AuthorizedKey>(query);
        }
    }

    public partial class AuthorizedKeyProfile : Profile
    {
        public AuthorizedKeyProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<AuthorizedKeyInput, AuthorizedKeyEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<AuthorizedKeyEntity, AuthorizedKey>());
        }

        void MapInputToEntity(IMappingExpression<AuthorizedKeyInput, AuthorizedKeyEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.AuthorizedKeyId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<AuthorizedKeyEntity, AuthorizedKey> mapExpr)
        {
            
        }
    }
}