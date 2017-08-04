
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace ConsoleApp2
{
	class Program
	{
		static void request()
		{
			// YouTubeService 객체 생성
			var youtube = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = "AIzaSyBEThgL-Cq85pSiZk5qt23Hvk6hUVuQVd4", // 키 지정
				ApplicationName = "My YouTube Search"
			});

			// Search용 Request 생성
			var request = youtube.Search.List("snippet");
			request.Q = "양희은";
			request.MaxResults = 25;

			// Search용 Request 실행
			var result = request.Execute();

			// Search 결과를 리스트뷰에 담기
			foreach (var item in result.Items)
			{
				if (item.Id.Kind == "youtube#video")
				{
					Console.WriteLine(item.Snippet.Title);
					//listView1.Items.Add(item.Id.VideoId.ToString(), , 0);
				}
			}
		}


		static void Main(string[] args)
		{

			request();
		}
	}
}
