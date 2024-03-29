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

exports.up = function(db, callback) {
    
    db.addIndex('User', 'User_UserName_IX', ['UserName'], true, callback);

    db.addForeignKey('UserLogin', 'User', 'UserLogin_User_FK',
    {
        'UserID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserClaim', 'User', 'UserClaim_User_FK',
    {
        'UserID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserRole', 'User', 'UserRole_User_FK',
    {
        'UserID': 'ID'
    },
    {
        onDelete: 'RESTRICT',
        onUpdate: 'RESTRICT'
    }, callback);

    db.addForeignKey('UserRole', 'Role', 'UserRole_Role_FK',
    {
        'RoleID': 'ID'
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
