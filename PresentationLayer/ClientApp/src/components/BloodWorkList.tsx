import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as BloodWorkStore from '../store/reducers/BloodWork';

// At runtime, Redux will merge together...
type BloodWorkProps =
  BloodWorkStore.BloodWorkState // ... state we've requested from the Redux store
  & typeof BloodWorkStore.actionCreators // ... plus action creators we've requested
  & RouteComponentProps<{ pageIndex: string }>; // ... plus incoming routing parameters


class BloodWorkList extends React.PureComponent<BloodWorkProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.ensureDataFetched();
  }

  // This method is called when the route parameters change
  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Blood Work Table</h1>
        {this.renderBloodWorkTable()}
        {this.renderPagination()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    const pageIndex = parseInt(this.props.match.params.pageIndex, 10) || 0;
    this.props.requestBloodWork(pageIndex);
  }

  private renderBloodWorkTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>ExamDate</th>
            <th>ResultsDate</th>
            <th>Description</th>
            <th>Hemoglobin (%)</th>
            <th>Hematocrit (%)</th>
            <th>White Blood Cell Count (Mill Cells/MicroLitre)</th>
            <th>Red Blood Cell Count (Mill Cells/MicroLitre)</th>
            <th colSpan={2}>Action</th>
          </tr>
        </thead>
        <tbody>
            {this.props.bloodWork ? this.props.bloodWork.map((bloodWork: BloodWorkStore.BloodWork) =>
                <tr key={bloodWork.id}>
                    <td>{bloodWork.dateCreated.split('T')[0]}</td>
                    <td>{bloodWork.examDate.split('T')[0]}</td>
                    <td>{bloodWork.resultsDate.split('T')[0]}</td>
                    <td>{bloodWork.description}</td>
                    <td>{bloodWork.hemoglobin}</td>
                    <td>{bloodWork.hematocrit}</td>
                    <td>{bloodWork.whiteBloodCellCountMCPMcL}</td>
                    <td>{bloodWork.redBloodCellCountMCPMcL}</td>
                    <td><Link className='fa fa-book' to={`/view-data/${bloodWork.id}`}>View</Link></td>
                    <td><Link className='fa fa-book' to={`/edit-data/${bloodWork.id}`}>Edit</Link></td>
                </tr>
                )
                    : <tr><td colSpan={8}>No Available Data</td></tr>}
        </tbody>
      </table>
    );
  }

  private renderPagination() {
    const prevPageIndex = Math.max((this.props.pageIndex || 1) - 1, 1);
    const nextPageIndex = Math.max((this.props.pageIndex || 1) + 1, 1);

    return (
      <div className="d-flex justify-content-between">
            <Link className='btn btn-outline-secondary btn-sm' aria-disabled={prevPageIndex <= 0} to={`/fetch-data/${prevPageIndex}`}>Previous</Link>
        {this.props.isLoading && <span>Loading...</span>}
            <Link className='btn btn-outline-secondary btn-sm' aria-disabled={prevPageIndex <= 0} to={`/fetch-data/${nextPageIndex}`}>Next</Link>
      </div>
    );
  }
}

export default connect(
  (state: ApplicationState) => state.bloodWork, // Selects which state properties are merged into the component's props
  BloodWorkStore.actionCreators // Selects which action creators are merged into the component's props
)(BloodWorkList as any);
