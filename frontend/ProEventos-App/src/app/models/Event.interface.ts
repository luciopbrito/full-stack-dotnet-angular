import { Batch } from "./Batch.interface"
import { SocialMedia } from "./SocialMedia.interface"

export interface Event {
  id: number
  local: string
  dateEvent: Date
  theme: string
  qtdPeople: number
  imageURL: string
  phone: string
  email: string
  batches?: Batch[]
  socialMedias?: SocialMedia[]
  speakerEvents?: Event[]
}
