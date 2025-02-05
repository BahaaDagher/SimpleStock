import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'SimpleStock',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44316/',
    redirectUri: baseUrl,
    clientId: 'SimpleStock_App',
    responseType: 'code',
    scope: 'offline_access SimpleStock',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44316',
      rootNamespace: 'SimpleStock',
    },
  },
} as Environment;
