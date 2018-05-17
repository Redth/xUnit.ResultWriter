using System.Collections.Generic;
using System.Xml;

namespace Xunit.ResultWriter
{
	public class XunitV2Writer
	{
		public void Write(List<Assembly> assemblies, string filename)
		{
			using (var xml = XmlWriter.Create(filename))
			{
				xml.WriteStartDocument();
				xml.WriteStartElement("assemblies");

				foreach (var a in assemblies)
				{
					xml.WriteStartElement("assembly");

					xml.WriteAttributeString("name", a.Name);
					xml.WriteAttributeString("environment", a.Environment);
					xml.WriteAttributeString("test-framework", a.TestFramework);
					xml.WriteAttributeString("run-date", a.RunDate);
					xml.WriteAttributeString("run-time", a.RunTime);
					xml.WriteAttributeString("total", a.Total.ToString());
					xml.WriteAttributeString("passed", a.Passed.ToString());
					xml.WriteAttributeString("failed", a.Failed.ToString());
					xml.WriteAttributeString("skipped", a.Skipped.ToString());
					xml.WriteAttributeString("time", a.Time.ToString());
					xml.WriteAttributeString("errors", a.Errors.ToString());

					xml.WriteStartElement("errors");
					foreach (var e in a.ErrorItems)
					{
						xml.WriteStartElement("error");
						xml.WriteAttributeString("name", e.Name);
						xml.WriteAttributeString("type", e.Type);

						if (e.Failure != null)
						{
							xml.WriteStartElement("failure");

							xml.WriteAttributeString("exception-type", e.Failure?.ExceptionType ?? string.Empty);

							xml.WriteStartElement("message");
							xml.WriteCData(e.Failure?.Message ?? string.Empty);
							xml.WriteEndElement();

							xml.WriteStartElement("stack-trace");
							xml.WriteCData(e.Failure?.StackTrace ?? string.Empty);
							xml.WriteEndElement();

							xml.WriteEndElement();
						}

						xml.WriteEndElement();
					}
					xml.WriteEndElement();

					foreach (var c in a.CollectionItems)
					{
						xml.WriteStartElement("collection");
						xml.WriteAttributeString("total", c.Total.ToString());
						xml.WriteAttributeString("passed", c.Passed.ToString());
						xml.WriteAttributeString("failed", c.Failed.ToString());
						xml.WriteAttributeString("skipped", c.Skipped.ToString());
						xml.WriteAttributeString("name", c.Name);
						xml.WriteAttributeString("time", c.Time.ToString());

						foreach (var t in c.TestItems)
						{
							var r = "Skip";
							if (t.Result == ResultType.Fail)
								r = "Fail";
							else if (t.Result == ResultType.Pass)
								r = "Pass";
							
							xml.WriteStartElement("test");
							xml.WriteAttributeString("name", t.Name);
							xml.WriteAttributeString("type", t.Type);
							xml.WriteAttributeString("method", t.Method);


							xml.WriteAttributeString("result", r);

							if (t.Failure != null)
							{
								xml.WriteStartElement("failure");
								xml.WriteAttributeString("exception-type", t.Failure?.ExceptionType ?? string.Empty);

								xml.WriteStartElement("message");
								xml.WriteCData(t.Failure?.Message ?? string.Empty);
								xml.WriteEndElement();

								xml.WriteStartElement("stack-trace");
								xml.WriteCData(t.Failure?.StackTrace ?? string.Empty);
								xml.WriteEndElement();

								xml.WriteEndElement();
							}

							xml.WriteEndElement();
						}

						xml.WriteEndElement();
					}

					xml.WriteEndElement();
				}

				xml.WriteEndElement();
				xml.WriteEndDocument();
			}
		}
	}
}
