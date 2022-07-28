import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class GameApiClient extends ModelApiClient<$models.Game> {
  constructor() { super($metadata.Game) }
}


export class GenreApiClient extends ModelApiClient<$models.Genre> {
  constructor() { super($metadata.Genre) }
}


export class GameServiceApiClient extends ServiceApiClient<typeof $metadata.GameService> {
  constructor() { super($metadata.GameService) }
  public getGames($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Game[]>> {
    const $method = this.$metadata.methods.getGames
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
}


