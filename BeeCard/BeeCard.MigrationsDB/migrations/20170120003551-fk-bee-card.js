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

    db.addForeignKey('Company', 'Plan', 'Company_Plan_FK',
      {
          'PlanID': 'ID'
      },
      {
          onDelete: 'RESTRICT',
          onUpdate: 'RESTRICT'
      }, callback);

    db.addForeignKey('Company', 'CompanyType', 'Company_CompanyType_FK',
    {
        'CompanyTypeID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('Company', 'Country', 'Company_Country_FK',
    {
        'CountryID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('CompanyGroup', 'Company', 'CompanyGroup_Company_FK',
    {
        'CompanyID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('CorporateCard', 'User', 'CorporateCard_User_FK',
    {
        'UserID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('CorporateCard', 'Company', 'CorporateCard_Company_FK',
    {
        'CompanyID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('Lead', 'CorporateCard', 'Lead_CorporateCard_FK',
    {
        'CorporateCardID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('Lead', 'PersonalCard', 'Lead_PersonalCard_FK',
    {
        'PersonalCardID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('PersonalCard', 'User', 'PersonalCard_User_FK',
    {
        'UserID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('SubscriptionHistory', 'Company', 'SubscriptionHistory_Company_FK',
    {
        'CompanyID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserGroup_PersonalCard', 'UserGroup', 'UserGroup_PersonalCard_UserGroup_FK',
    {
        'UserGroupID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserGroup_PersonalCard', 'PersonalCard', 'UserGroup_PersonalCard_PersonalCard_FK',
    {
        'PersonalCardID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserGroup_CorporateCard', 'UserGroup', 'UserGroup_CorporateCard_UserGroup_FK',
    {
        'UserGroupID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserGroup_CorporateCard', 'CorporateCard', 'UserGroup_CorporateCard_CorporateCard_FK',
    {
        'CorporateCardID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
