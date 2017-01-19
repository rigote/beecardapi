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
    db.createTable('User', {
        ID: { type: 'string', primaryKey: true },
        Firstname: { type: 'string', notNull: true, length: 100 },
        Lastname: { type: 'string', notNull: true, length: 150 },
        Email: { type: 'string', notNull: true, length: 100 },
        Password: { type: 'string', notNull: true, length: 500 },
        Cellphone: { type: 'string', notNull: true, length: 50 },
        Birthdate: { type: 'date', notNull: true },
        Photo: { type: 'string', notNull: false, length: 50 },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
