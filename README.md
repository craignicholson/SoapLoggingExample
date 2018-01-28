# SoapLoggingExample

## Problem

Sometimes when sending web requests or soap messages you might need to track the
requests and responses you are sending.  This example demonstrates how to implement
a Soap Extension and use log4net to log the request and response streams.

## Dependencies

## log4net Settup

## How this works

## log4net output

```bash
2018-01-27 19:48:27,954 | Main | Enter
2018-01-27 19:48:28,025 | Main | CallWebService Starting
2018-01-27 19:48:32,296 | GetInitializer | GetInitializer(Type serviceType)
2018-01-27 19:48:32,349 | Initialize | Initialize
2018-01-27 19:48:32,364 | ChainStream | ChainStream
2018-01-27 19:48:32,381 | ProcessMessage | BeforeSerialize
2018-01-27 19:48:32,400 | ProcessMessage | Soap11
2018-01-27 19:48:32,519 | ProcessMessage | AfterSerialize
2018-01-27 19:48:32,540 | ProcessMessage | Soap11
2018-01-27 19:48:32,570 | PrettyXml | REQUEST | <?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Header><MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="45bcd207-789f-4d99-a0a1-9b92a5f0ad03" TimeStamp="2018-01-27T19:48:32.3163856-05:00" xmlns="http://www.multispeak.org/Version_3.0" /></soap:Header><soap:Body><GetOutageDurationEvents xmlns="http://www.multispeak.org/Version_3.0"><outageEventID>2017-10-27-0003</outageEventID></GetOutageDurationEvents></soap:Body></soap:Envelope>
2018-01-27 19:48:32,587 | PrettyXml | Formatted |
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Header>
    <MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="45bcd207-789f-4d99-a0a1-9b92a5f0ad03" TimeStamp="2018-01-27T19:48:32.3163856-05:00" xmlns="http://www.multispeak.org/Version_3.0" />
  </soap:Header>
  <soap:Body>
    <GetOutageDurationEvents xmlns="http://www.multispeak.org/Version_3.0">
      <outageEventID>2017-10-27-0003</outageEventID>
    </GetOutageDurationEvents>
  </soap:Body>
</soap:Envelope>
2018-01-27 19:48:32,605 | CopyStream | CopyStream
2018-01-27 19:48:32,997 | ChainStream | ChainStream
2018-01-27 19:48:33,035 | ProcessMessage | BeforeDeserialize
2018-01-27 19:48:33,072 | ProcessMessage | Soap11
2018-01-27 19:48:33,118 | CopyStream | CopyStream
2018-01-27 19:48:33,166 | PrettyXml | RESPONSE | <?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Header><MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="45bcd207-789f-4d99-a0a1-9b92a5f0ad03" TimeStamp="2018-01-27T18:48:32.3163856-06:00" xmlns="http://www.multispeak.org/Version_3.0" /></soap:Header><soap:Body><GetOutageDurationEventsResponse xmlns="http://www.multispeak.org/Version_3.0"><GetOutageDurationEventsResult><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>99280326</meterNo><servLoc>130371</servLoc><accountNumber>217636001</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>99027630</meterNo><servLoc>130372</servLoc><accountNumber>213291003</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent><outageDurationEvent objectID="{5DC0365A-BB4A-11E7-9667-0050569C0462}" utility="GVEC"><outageEventID>2017-10-27-0003</outageEventID><outageDescription>Transformer T61563680002 Restored</outageDescription><meterNo>96474458</meterNo><servLoc>130373</servLoc><accountNumber>215704001</accountNumber><timeOfInterruption>2017-10-27T14:00:14-05:00</timeOfInterruption><timeRestored>2017-10-27T14:01:02-05:00</timeRestored><interruptionDuration>1</interruptionDuration><customerResponsible>false</customerResponsible></outageDurationEvent></GetOutageDurationEventsResult></GetOutageDurationEventsResponse></soap:Body></soap:Envelope>
2018-01-27 19:48:33,214 | PrettyXml | Formatted |
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Header>
    <MultiSpeakMsgHeader Version="3.0ac" UserID="User123" Pwd="***********" AppName="TestApp" AppVersion="0" Company="ElectSolve" MessageID="45bcd207-789f-4d99-a0a1-9b92a5f0ad03" TimeStamp="2018-01-27T18:48:32.3163856-06:00" xmlns="http://www.multispeak.org/Version_3.0" />
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
2018-01-27 19:48:33,507 | ProcessMessage | AfterDeserialize
2018-01-27 19:48:33,537 | ProcessMessage | Soap11
2018-01-27 19:48:33,572 | Main | CallWebService Done

```

## References