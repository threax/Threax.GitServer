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
        public GitRepoEntity MapGitRepo(GitRepoInput src, GitRepoEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public GitRepo MapGitRepo(GitRepoEntity src, GitRepo dest)
        {
            return mapper.Map(src, dest);
        }

        public IQueryable<GitRepo> ProjectGitRepo(IQueryable<GitRepoEntity> query)
        {
            return mapper.ProjectTo<GitRepo>(query);
        }
    }

    public partial class GitRepoProfile : Profile
    {
        public GitRepoProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<GitRepoInput, GitRepoEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<GitRepoEntity, GitRepo>());
        }

        void MapInputToEntity(IMappingExpression<GitRepoInput, GitRepoEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.GitRepoId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<GitRepoEntity, GitRepo> mapExpr)
        {
            
        }
    }
}