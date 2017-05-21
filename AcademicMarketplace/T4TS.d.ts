﻿/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module Models.BalanceModel {
    /** Generated from AcademicMarketplace.Controllers.Models.BalanceModel **/
    export interface IBalanceModel {
        user: string;
        balance?: number;
        user1: Models.UserModel.IUserModel;
    }
}

declare module Models.PostModel {
    /** Generated from AcademicMarketplace.Controllers.Models.MarketplaceListingModel **/
    export interface IMarketplaceListingModel {
        id: number;
        workgroup: string;
        name: string;
        description: string;
        image: string;
        workgroup1: any;
        serviceRequests: any[];
    }
}

declare module Models.UserModel {
    /** Generated from AcademicMarketplace.Controllers.Models.UserModel **/
    export interface IUserModel {
        id: string;
        username: string;
        email: string;
        firstName: string;
        surname: string;
        location: string;
        balance: Models.BalanceModel.IBalanceModel;
        serviceRequests: any[];
        workgroups: any[];
    }
}
