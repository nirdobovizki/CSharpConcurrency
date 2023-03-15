using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Chapter03
{

   public class Listing1_ContinueWith
   {
         public void GetBitmapWidth(string path)
         {
			var file = new FileStream(path, FileMode.Open, FileAccess.Read);
			var fileId = new byte[2];
			file.ReadAsync(fileId, 0, 2, CancellationToken.None).
				ContinueWith(firstReadTask =>
				{
					int read = firstReadTask.Result;
					if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
					{
						// get error to caller somehow
						Console.WriteLine("Not a bitmap");
						return;		
					}
					file.Seek(18, SeekOrigin.Begin);
					var widthBuffer = new byte[4];
					file.ReadAsync(widthBuffer, 0, 4, CancellationToken.None).
						ContinueWith(secondReadTask =>
						{
							read = secondReadTask.Result;
							if (read != 4) throw new Exception("Not a BMP file");
							var result = BitConverter.ToInt32(widthBuffer, 0);
							// get result back to our caller somehow
							Console.WriteLine(result);
							return;
						});
				});
		}
   }
}
