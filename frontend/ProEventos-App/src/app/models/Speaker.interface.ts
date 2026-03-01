import { Event } from "./Event.interface"
import { SocialMedia } from "./SocialMedia.interface"

export interface Speaker {
  id: number
  name: string
  smallCV: string
  imageURL: string
  phone: string
  email: string
  socialMedias?: SocialMedia[]
  speakerEvents?: Event[]
}
