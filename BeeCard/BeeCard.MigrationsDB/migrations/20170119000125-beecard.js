'use strict';

var dbm;
var type;
var seed;

/**
  * We receive the dbmigrate dependency from dbmigrate initially.
  * This enables us to not have to rely on NODE_PATH.
  */
exports.setup = function(options, seedLink) {
  dbm = options.dbmigrate;
  type = dbm.dataType;
  seed = seedLink;
};

exports.up = function (db, callback) {

    db.createTable('User', {
        ID: { type: 'uuid', primaryKey: true },
        Firstname: { type: 'string', notNull: true, length: 100 },
        Lastname: { type: 'string', notNull: true, length: 150 },
        Email: { type: 'string', notNull: true, length: 100 },
        Birthdate: { type: 'date', notNull: true },
        Photo: { type: 'string', notNull: false, length: 50 },
        AccessFailedCount: { type: 'int', notNull: false },
        EmailConfirmed: { type: 'boolean', notNull: false },
        LockoutEnabled: { type: 'boolean', notNull: false },
        LockoutEndDateUtc: { type: 'datetime', notNull: false },
        PasswordHash: { type: 'string', notNull: false, length: 500 },
        PhoneNumber: { type: 'string', notNull: false, length: 255 },
        PhoneNumberConfirmed: { type: 'boolean', notNull: false },
        SecurityStamp: { type: 'string', notNull: false, length: 500 },
        TwoFactorEnabled: { type: 'boolean', notNull: false },
        UserName: { type: 'string', notNull: false, length: 255 },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('Company', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true },
        Address: { type: 'string', notNull: true, length: 150 },
        PostalCode: { type: 'string', notNull: true },
        Neighborhood: { type: 'string', notNull: true },
        City: { type: 'string', notNull: true, length: 100 },
        State: { type: 'string', notNull: true },
        ContactName: { type: 'string', notNull: true, length: 200 },
        ContactEmail: { type: 'string', notNull: true, length: 100 },
        ContactPhone: { type: 'string', notNull: true, length: 50 },
        Password: { type: 'string', notNull: true, length: 500 },
        SubscriptionType: { type: 'int', notNull: false },
        SubscriptionPrice: { type: 'decimal', notNull: false },
        SubscriptionDate: { type: 'datetime', notNull: false },
        SubscriptionStatus: { type: 'int', notNull: false },
        Logo: { type: 'string', notNull: false, length: 50 },
        Website: { type: 'string', notNull: false, length: 200 },
        SocialNetwork: { type: 'string', notNull: false, length: 1000 },
        PlanID: { type: 'uuid', notNull: true },
        CountryID: { type: 'uuid', notNull: true },
        CompanyTypeID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('CompanyGroup', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 100 },
        CompanyID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('CompanyType', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 150 },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('CorporateCard', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: false, length: 200 },
        Email: { type: 'string', notNull: false, length: 100 },
        Phone: { type: 'string', notNull: false, length: 100 },
        Cellphone: { type: 'string', notNull: false, length: 100 },
        Occupation: { type: 'string', notNull: false, length: 100 },
        Department: { type: 'string', notNull: false, length: 100 },
        CompanyID: { type: 'uuid', notNull: true },
        UserID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('Country', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 200 },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('Lead', {
        ID: { type: 'uuid', primaryKey: true },
        PersonalCardID: { type: 'uuid', notNull: false },
        CorporateCardID: { type: 'uuid', notNull: false },
        RequestStatus: { type: 'int', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('PersonalCard', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: false, length: 200 },
        Email: { type: 'string', notNull: false, length: 100 },
        Phone: { type: 'string', notNull: false, length: 100 },
        Cellphone: { type: 'string', notNull: false, length: 100 },
        Address: { type: 'string', notNull: false, length: 150 },
        Website: { type: 'string', notNull: false, length: 200 },
        SocialNetwork: { type: 'string', notNull: false, length: 1000 },
        UserID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('Plan', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 100 },
        Description: { type: 'string', notNull: false, length: 500 },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('SubscriptionHistory', {
        ID: { type: 'uuid', primaryKey: true },
        SubscriptionType: { type: 'int', notNull: true },
        SubscriptionPrice: { type: 'decimal', notNull: true },
        SubscriptionDate: { type: 'datetime', notNull: true },
        SubscriptionStatus: { type: 'int', notNull: true },
        CompanyID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('UserGroup', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 100 },
        UserID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    db.createTable('UserGroup_PersonalCard', {
        PersonalCardID: { type: 'uuid', primaryKey: true },
        UserGroupID: { type: 'uuid', primaryKey: true }
    }, callback);    

    db.createTable('UserGroup_CorporateCard', {
        CorporateCardID: { type: 'uuid', primaryKey: true },
        UserGroupID: { type: 'uuid', primaryKey: true }
    }, callback);

    db.createTable('Role', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 255 }
    }, callback);

    db.createTable('UserRole', {
        UserID: { type: 'uuid', primaryKey: true },
        RoleID: { type: 'uuid', primaryKey: true }
    }, callback);

    db.createTable('UserClaim', {
        ID: { type: 'uuid', primaryKey: true },
        UserID: { type: 'uuid', notNull: true },
        ClaimValue: { type: 'string', notNull: true, length: 255 },
        ClaimType: { type: 'string', notNull: true, length: 255 }
    }, callback);

    db.createTable('UserLogin', {
        LoginProvider: { type: 'string', primaryKey: true, length: 500 },
        ProviderKey: { type: 'string', primaryKey: true, length: 500 },
        UserID: { type: 'uuid', primaryKey: true }
    }, callback);

};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
