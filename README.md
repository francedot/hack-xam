# EyeCare

**EyeCare** is the prototype of an app developed at [OxfordHack 2017](http://oxfordhack.com) for the main challenge on AI by Microsoft.

By leveraging the power of Microsoft Azure and Cognitive Services, EyeCare wants to help optometrists diagnose eye disorders and users to receive feedback starting from a picture of the eyes. The system has been designed so that the specialist, in this case the eye doctor, can participate to the refining of Eyecare’s Computer Vision model.

In just 24 hours we came up with a consumer mobile app to be used by the final user and a web portal for the specialists.
Through the web portal, the optometrist can check diagnosis details and provide an evaluation that serves as an input to a Custom Vision API node for its continuous training.

The client mobile app for iOS, Android and Windows has been developed using Xamarin while an ASP.NET Core backend acts as a middleware with the client app, the Azure Custom Vision API endpoint and the specialists web portal.
The web portal has been developed using PHP and Bootstrap and deployed as an Azure Website. 


## Mobile App
<img src="https://preview.ibb.co/bPJPnc/1.png" width="340">

## Web Portal
<img src="https://preview.ibb.co/fVgc7c/2.png" width="700">
