# SoapLoggingExample

## Problem

Sometimes when sending web requests or soap messages you might need to track the
requests and responses you are sending.  This example demonstrates how to implement
a Soap Extension and use log4net to log the request and response streams.

## Dependencies

- log4net
- System.Web.Services
- Your own web service (soap)  for .net folks thi is a .asmx or wcf (.svc)

## log4net Settup

- Add log4net via NuGet
- Add log4net.config file
- Add log4net code to AssemblyInfo.cs

```C#
// Manually Add of log4net by Craig Nicholson
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]
```

## How this works

## log4net output

This is what you would want in your log if you are using an log aggregator like ElasticSearch, Logstash, and Kibana (ELK).

```bash
2018-01-27 21:22:17,204 | Main | Enter
2018-01-27 21:22:17,247 | Main | CallWebService Starting
2018-01-27 21:22:21,792 | GetInitializer | GetInitializer(Type serviceType)
2018-01-27 21:22:21,836 | Initialize | Initialize
2018-01-27 21:22:21,850 | ChainStream | ChainStream
2018-01-27 21:22:21,866 | ProcessMessage | Stage : BeforeSerialize
2018-01-27 21:22:21,982 | ProcessMessage | Stage : AfterSerialize
2018-01-27 21:22:22,005 | WriteOutput | Request | <?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Header><MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="5315821d-35e5-4a73-8529-81068d838709" TimeStamp="2018-01-27T21:22:21.8119783-05:00" xmlns="http://www.multispeak.org/Version_3.0" /></soap:Header><soap:Body><GetOutageDurationEvents xmlns="http://www.multispeak.org/Version_3.0"><outageEventID>2017-10-27-0003</outageEventID></GetOutageDurationEvents></soap:Body></soap:Envelope>
2018-01-27 21:22:22,028 | CopyStream | CopyStream
2018-01-27 21:22:22,924 | ChainStream | ChainStream
2018-01-27 21:22:22,946 | ProcessMessage | Stage : BeforeDeserialize
2018-01-27 21:22:22,969 | CopyStream | CopyStream
2018-01-27 21:22:22,995 | WriteInput | Response | <?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Header><MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="5315821d-35e5-4a73-8529-81068d838709" TimeStamp="2018-01-27T20:22:21.8119783-06:00" xmlns="http://www.multispeak.org/Version_3.0" /></soap:Header><soap:Body><GetOutageDurationEventsResponse xmlns="http://www.multispeak.org/Version_3.0"><GetOutageDurationEventsResult><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>99280326</meterNo><servLoc>130371</servLoc><accountNumber>217636001</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>99027630</meterNo><servLoc>130372</servLoc><accountNumber>213291003</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>96474458</meterNo><servLoc>130373</servLoc><accountNumber>215704001</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent></GetOutageDurationEventsResult></GetOutageDurationEventsResponse></soap:Body></soap:Envelope>
2018-01-27 21:22:23,113 | ProcessMessage | Stage : AfterDeserialize
2018-01-27 21:22:23,137 | Main | CallWebService Done

```

If you wish to output a more readable format use PrettyXml.

```bash
2018-01-27 21:25:12,160 | Main | Enter
2018-01-27 21:25:12,205 | Main | CallWebService Starting
2018-01-27 21:25:18,845 | GetInitializer | GetInitializer(Type serviceType)
2018-01-27 21:25:18,925 | Initialize | Initialize
2018-01-27 21:25:18,951 | ChainStream | ChainStream
2018-01-27 21:25:18,978 | ProcessMessage | Stage : BeforeSerialize
2018-01-27 21:25:19,141 | ProcessMessage | Stage : AfterSerialize
2018-01-27 21:25:19,209 | WriteOutput | <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Header>
    <MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="cc0afc12-923c-455c-a937-fec00055ef58" TimeStamp="2018-01-27T21:25:18.8814632-05:00" xmlns="http://www.multispeak.org/Version_3.0" />
  </soap:Header>
  <soap:Body>
    <GetOutageDurationEvents xmlns="http://www.multispeak.org/Version_3.0">
      <outageEventID>2017-10-27-0003</outageEventID>
    </GetOutageDurationEvents>
  </soap:Body>
</soap:Envelope>
2018-01-27 21:25:19,263 | CopyStream | CopyStream
2018-01-27 21:25:20,180 | ChainStream | ChainStream
2018-01-27 21:25:20,229 | ProcessMessage | Stage : BeforeDeserialize
2018-01-27 21:25:20,274 | CopyStream | CopyStream
2018-01-27 21:25:20,317 | WriteInput | <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Header>
    <MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="cc0afc12-923c-455c-a937-fec00055ef58" TimeStamp="2018-01-27T20:25:18.8814632-06:00" xmlns="http://www.multispeak.org/Version_3.0" />
  </soap:Header>
  <soap:Body>
    <GetOutageDurationEventsResponse xmlns="http://www.multispeak.org/Version_3.0">
      <GetOutageDurationEventsResult>
        <outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC">
          <outageEventID>2017-10-27-0003</outageEventID>
          <outageDescription>Transformer T61563680002 Restored</outageDescription>
          <meterNo>99280326</meterNo>
          <servLoc>130371</servLoc>
          <accountNumber>217636001</accountNumber>
          <timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption>
          <timeRestored>2017-10-27T14:01:02-05:00</timeRestored>
          <interruptionDuration>1</interruptionDuration>
          <customerResponsible>false</customerResponsible>
        </outageDurationEvent>
        <outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC">
          <outageEventID>2017-10-27-0003</outageEventID>
          <outageDescription>Transformer T61563680002 Restored</outageDescription>
          <meterNo>99027630</meterNo>
          <servLoc>130372</servLoc>
          <accountNumber>213291003</accountNumber>
          <timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption>
          <timeRestored>2017-10-27T14:01:02-05:00</timeRestored>
          <interruptionDuration>1</interruptionDuration>
          <customerResponsible>false</customerResponsible>
        </outageDurationEvent>
        <outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC">
          <outageEventID>2017-10-27-0003</outageEventID>
          <outageDescription>Transformer T61563680002 Restored</outageDescription>
          <meterNo>96474458</meterNo>
          <servLoc>130373</servLoc>
          <accountNumber>215704001</accountNumber>
          <timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption>
          <timeRestored>2017-10-27T14:01:02-05:00</timeRestored>
          <interruptionDuration>1</interruptionDuration>
          <customerResponsible>false</customerResponsible>
        </outageDurationEvent>
      </GetOutageDurationEventsResult>
    </GetOutageDurationEventsResponse>
  </soap:Body>
</soap:Envelope>
2018-01-27 21:25:20,544 | ProcessMessage | Stage : AfterDeserialize
2018-01-27 21:25:20,568 | Main | CallWebService Done

```

## References

[How to: Implement a SOAP Extension](https://msdn.microsoft.com/en-us/library/7w06t139(v=vs.100).aspx)
[How to: Implement the ChainStream Method to Save References to Stream Objects](https://msdn.microsoft.com/en-us/library/eyxt5kaw(v=vs.100).aspx)
