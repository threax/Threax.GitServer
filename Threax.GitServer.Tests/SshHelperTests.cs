//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using Threax.AspNetCore.Tests;
//using Threax.GitServer.Services;
//using Xunit;

//namespace Threax.GitServer.Tests
//{
//    public class SshHelperTests
//    {
//        private Mockup mockup = new Mockup().SetupGlobal();

//        public SshHelperTests()
//        {
//            mockup.Add<IRepoFolderProvider>(s => new RepoFolderProvider("/repo"));
//            mockup.MockServiceCollection.AddScoped<IProcessRunner, ProcessRunner>();
//            mockup.Add<SshHelper>(s => new SshHelper("threax@127.0.0.1", "2222", s.Get<IRepoFolderProvider>(), s.Get<IProcessRunner>()));
//        }

//        private String GetRepoName([System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
//        {
//            return $"SshHelperTests-{memberName}";
//        }

//        [Fact]
//        async Task DoesNotExist()
//        {
//            var sshHelper = mockup.Get<SshHelper>();
//            var repoName = GetRepoName();
//            var result = await sshHelper.RepoExists(repoName);
//            Assert.False(result);
//        }

//        [Fact]
//        async Task Exists()
//        {
//            var sshHelper = mockup.Get<SshHelper>();
//            var repoName = GetRepoName();
//            try
//            {
//                await sshHelper.CreateRepo(repoName);
//                var result = await sshHelper.RepoExists(repoName);
//                Assert.True(result);
//            }
//            finally
//            {
//                await sshHelper.DeleteRepo(repoName);
//            }
//        }

//        [Fact]
//        async Task AddAndDelete()
//        {
//            var sshHelper = mockup.Get<SshHelper>();
//            var repoName = GetRepoName();
//            try
//            {
//                await sshHelper.CreateRepo(repoName);
//            }
//            finally
//            {
//                await sshHelper.DeleteRepo(repoName);
//            }
//        }
//    }
//}
