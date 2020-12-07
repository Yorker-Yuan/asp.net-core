import { BankAccountService } from './../shared/bank-account.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import { BankService } from '../shared/bank.service';

@Component({
  selector: 'app-bank-account',
  templateUrl: './bank-account.component.html',
  styleUrls: []
})
export class BankAccountComponent implements OnInit {

  bankAccountForms: FormArray = this.fb.array([]);
  bankList = [];
  // notification = null;

  constructor(private fb: FormBuilder,
    private bankService: BankService,
    private service: BankAccountService) { }

  ngOnInit() {
    this.bankService.getBankList()
      .subscribe(res => this.bankList = res as []);

    this.service.getBankAccountList().subscribe(
      res => {
        if (res == [])
          this.addBankAccountForm();
        else {
          //generate formarray as per the data received from BankAccont table
          (res as []).forEach((bankAccount: any) => {
            this.bankAccountForms.push(this.fb.group({
              fBankAccountId: [bankAccount.fBankAccountId],
              fAccountNumber: [bankAccount.fAccountNumber, Validators.required],
              fAccountHolder: [bankAccount.fAccountHolder, Validators.required],
              fBankId: [bankAccount.fBankId, Validators.min(1)],
              fIFSC: [bankAccount.fIFSC, Validators.required]
            }));
          });
        }
      }
    );
  }

  addBankAccountForm() {
    this.bankAccountForms.push(this.fb.group({
      fBankAccountId: [0],
      fAccountNumber: ['', Validators.required],
      fAccountHolder: ['', Validators.required],
      fBankId: [0, Validators.min(1)],
      fIFSC: ['', Validators.required]
    }));
  }

  recordSubmit(fg: FormGroup) {
    if (fg.value.fBankAccountId == 0)
      this.service.postBankAccount(fg.value).subscribe(
        (res: any) => {
          fg.patchValue({ fBankAccountId: res.fBankAccountId });
          // this.showNotification('insert');
        });
    else
      this.service.putBankAccount(fg.value).subscribe(
        (res: any) => {
          // this.showNotification('update');
        });
  }

  onDelete(fBankAccountId:any, i:any) {
    if (fBankAccountId == 0)
      this.bankAccountForms.removeAt(i);
    else if (confirm('Are you sure to delete this record ?'))
      this.service.deleteBankAccount(fBankAccountId).subscribe(
        res => {
          this.bankAccountForms.removeAt(i);
          // this.showNotification('delete');
        });
  }

  // showNotification(category:any) {
  //   switch (category) {
  //     case 'insert':
  //       this.notification = { class: 'text-success', message: 'saved!' };
  //       break;
  //     case 'update':
  //       this.notification = { class: 'text-primary', message: 'updated!' };
  //       break;
  //     case 'delete':
  //       this.notification = { class: 'text-danger', message: 'deleted!' };
  //       break;

  //     default:
  //       break;
  //   }
  //   setTimeout(() => {
  //     this.notification = null;
  //   }, 3000);
  // }
}